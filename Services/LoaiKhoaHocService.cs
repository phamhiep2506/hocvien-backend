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
                StatusCodes.Status202Accepted,
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
                StatusCodes.Status202Accepted,
                ResponsesMessages.CreateDataFailed
            );
        }

        return _responses.StatusMessages(
            StatusCodes.Status201Created,
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
                StatusCodes.Status202Accepted,
                ResponsesMessages.DataNotExist
            );
        }

        _mapper.Map<UpdateLoaiKhoaHocDto, LoaiKhoaHoc>(
            updateLoaiKhoaHocDto,
            loaiKhoaHoc
        );

        try
        {
            _context.Update(loaiKhoaHoc);
            _context.SaveChanges();
        }
        catch
        {
            return _responses.StatusMessages(
                StatusCodes.Status202Accepted,
                ResponsesMessages.UpdateDataFailed
            );
        }

        return _responses.StatusMessages(
            StatusCodes.Status200OK,
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
                StatusCodes.Status202Accepted,
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
                StatusCodes.Status202Accepted,
                ResponsesMessages.DeleteDataFailed
            );
        }

        return _responses.StatusMessages(
            StatusCodes.Status200OK,
            ResponsesMessages.DeleteDataSuccess
        );
    }

    public IResponses GetLoaiKhoaHoc()
    {
        List<LoaiKhoaHoc>? loaiKhoaHocs = _context.LoaiKhoaHoc?.ToList();

        if (loaiKhoaHocs == null)
        {
            return _responses.StatusMessages(
                StatusCodes.Status202Accepted,
                ResponsesMessages.DataNull
            );
        }

        List<GetLoaiKhoaHocDto> getLoaiKhoaHocDtos = _mapper.Map<
            List<LoaiKhoaHoc>,
            List<GetLoaiKhoaHocDto>
        >(loaiKhoaHocs);

        return _responses.StatusMessagesData(
            StatusCodes.Status200OK,
            ResponsesMessages.GetDataSuccess,
            getLoaiKhoaHocDtos
        );
    }
}
