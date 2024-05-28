using AutoMapper;
using Dtos.HocVien;
using Helpers;
using Interfaces.IPayloads;
using Interfaces.IServices;
using Models;
using Payloads;

namespace Services;

public class HocVienService : IHocVienService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly IResponses _responses;

    public HocVienService(
        IMapper mapper,
        ApplicationDbContext context,
        IResponses responses
    )
    {
        _mapper = mapper;
        _context = context;
        _responses = responses;
    }

    public IResponses CreateHocVien(CreateHocVienDto createHocVienDto)
    {
        if (
            _context.HocVien!.Any(x =>
                x.Email == createHocVienDto.Email
                && x.SoDienThoai == createHocVienDto.SoDienThoai
            )
        )
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataExisted
            );
        }

        HocVien hocVien = _mapper.Map<CreateHocVienDto, HocVien>(
            createHocVienDto
        );

        try
        {
            _context.Add(hocVien);
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

    public IResponses UpdateHocVien(UpdateHocVienDto updateHocVienDto)
    {
        HocVien? hocVien = _context
            .HocVien?.Where(x => x.HocVienId == updateHocVienDto.HocVienId)
            .SingleOrDefault();

        if (hocVien == null)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNotExist
            );
        }

        _mapper.Map(updateHocVienDto, hocVien);

        try
        {
            _context.Update(hocVien);
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

    public IResponses DeleteHocVien(DeleteHocVienDto deleteHocVienDto)
    {
        HocVien? hocVien = _context
            .HocVien?.Where(x => x.HocVienId == deleteHocVienDto.HocVienId)
            .SingleOrDefault();

        if (hocVien == null)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNotExist
            );
        }

        try
        {
            _context.Remove(hocVien);
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

    public IResponses GetHocVien(int page, int pageSize)
    {
        List<HocVien> hocViens = _context
            .HocVien!.OrderBy(x => x.HocVienId)
            .ToList();

        if (hocViens.Count == 0)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNull
            );
        }

        List<HocVien> hocVienPaginations = PaginationHelper<HocVien>.Pagination(
            hocViens,
            page,
            pageSize
        );

        List<GetHocVienDto> getHocVienDtos = _mapper.Map<
            List<HocVien>,
            List<GetHocVienDto>
        >(hocVienPaginations);

        return _responses.StatusMessagesData(
            ResponsesStatus.Success,
            ResponsesMessages.GetDataSuccess,
            getHocVienDtos
        );
    }
}
