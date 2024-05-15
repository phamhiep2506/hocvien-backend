using AutoMapper;
using Dtos.LoaiKhoaHoc;
using Interfaces.IPayloads;
using Interfaces.IServices;
using Microsoft.EntityFrameworkCore;
using Models;
using Payloads;

namespace Services;

public class LoaiKhoaHocService : ILoaiKhoaHocService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly IResponses _responses;

    public LoaiKhoaHocService(
        IMapper mapper,
        ApplicationDbContext context,
        IResponses responses
    )
    {
        _mapper = mapper;
        _context = context;
        _responses = responses;
    }

    public IResponses CreateLoaiKhoaHoc(
        CreateLoaiKhoaHocDto createLoaiKhoaHocDto
    )
    {
        if (
            _context.LoaiKhoaHoc!.Any(x =>
                x.TenLoai == createLoaiKhoaHocDto.TenLoai
            )
        )
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataExisted
            );
        }

        LoaiKhoaHoc loaiKhoaHoc = _mapper.Map<
            CreateLoaiKhoaHocDto,
            LoaiKhoaHoc
        >(createLoaiKhoaHocDto);

        try
        {
            _context.Add(loaiKhoaHoc);
            _context.SaveChanges();
        }
        catch
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.CreateDataFailed
            );
        }

        return _responses.StatusMessages(
            ResponsesStatus.Success,
            ResponsesMessages.CreateDataSuccess
        );
    }

    public IResponses UpdateLoaiKhoaHoc(
        UpdateLoaiKhoaHocDto updateLoaiKhoaHocDto
    )
    {
        LoaiKhoaHoc? loaiKhoaHoc = _context
            .LoaiKhoaHoc?.AsNoTracking()
            .Where(x => x.LoaiKhoaHocId == updateLoaiKhoaHocDto.LoaiKhoaHocId)
            .SingleOrDefault();

        if (loaiKhoaHoc == null)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNotExist
            );
        }

        _mapper.Map(updateLoaiKhoaHocDto, loaiKhoaHoc);

        try
        {
            _context.Update(loaiKhoaHoc);
            _context.SaveChanges();
        }
        catch
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.UpdateDataFailed
            );
        }

        return _responses.StatusMessages(
            ResponsesStatus.Success,
            ResponsesMessages.UpdateDataSuccess
        );
    }

    public IResponses DeleteLoaiKhoaHoc(
        DeleteLoaiKhoaHocDto deleteLoaiKhoaHocDto
    )
    {
        LoaiKhoaHoc? loaiKhoaHoc = _context
            .LoaiKhoaHoc?.AsNoTracking()
            .Where(x => x.LoaiKhoaHocId == deleteLoaiKhoaHocDto.LoaiKhoaHocId)
            .SingleOrDefault();

        if (loaiKhoaHoc == null)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNotExist
            );
        }

        try
        {
            _context.Remove(loaiKhoaHoc);
            _context.SaveChanges();
        }
        catch
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DeleteDataFailed
            );
        }

        return _responses.StatusMessages(
            ResponsesStatus.Success,
            ResponsesMessages.DeleteDataSuccess
        );
    }

    public IResponses GetLoaiKhoaHoc()
    {
        List<LoaiKhoaHoc> loaiKhoaHocs = _context.LoaiKhoaHoc!.ToList();

        if (loaiKhoaHocs.Count == 0)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNull
            );
        }

        List<GetLoaiKhoaHocDto> getLoaiKhoaHocDtos = _mapper.Map<
            List<LoaiKhoaHoc>,
            List<GetLoaiKhoaHocDto>
        >(loaiKhoaHocs);

        return _responses.StatusMessagesData(
            ResponsesStatus.Success,
            ResponsesMessages.GetDataSuccess,
            getLoaiKhoaHocDtos
        );
    }
}
