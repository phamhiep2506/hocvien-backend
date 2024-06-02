using AutoMapper;
using Dtos.DangKyHoc;
using Helpers;
using Interfaces.IPayloads;
using Interfaces.IServices;
using Models;
using Payloads;

namespace Services;

public class DangKyHocService : IDangKyhocService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly IResponses _responses;

    public DangKyHocService(
        IMapper mapper,
        ApplicationDbContext context,
        IResponses responses
    )
    {
        _mapper = mapper;
        _context = context;
        _responses = responses;
    }

    public IResponses CreateDangKyHoc(CreateDangKyHocDto createDangKyHocDto)
    {
        DangKyHoc dangKyHoc = _mapper.Map<CreateDangKyHocDto, DangKyHoc>(
            createDangKyHocDto
        );

        try
        {
            _context.Add(dangKyHoc);
            _context.SaveChanges();
        }
        catch
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.CreateDataFailed
            );
        }

        KhoaHoc? khoaHoc = _context
            .KhoaHoc?.Where(x => x.KhoaHocId == dangKyHoc.KhoaHocId)
            .SingleOrDefault();

        if (khoaHoc == null)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNull
            );
        }

        khoaHoc.SoHocVien += 1;

        dangKyHoc.NgayKetThuc = new DateTime(
            dangKyHoc.NgayBatDau!.Value.Year,
            dangKyHoc.NgayBatDau.Value.Month,
            dangKyHoc.NgayBatDau.Value.Day
        ).AddMonths((int) khoaHoc.ThoiGianHoc!);

        _context.Update(dangKyHoc);
        _context.SaveChanges();

        return _responses.StatusMessages(
            ResponsesStatus.Success,
            ResponsesMessages.CreateDataSuccess
        );
    }

    public IResponses UpdateDangKyHoc(UpdateDangKyHocDto updateDangKyHocDto)
    {
        DangKyHoc? dangKyHoc = _context
            .DangKyHoc?
            .Where(x => x.DangKyHocId == updateDangKyHocDto.DangKyHocId)
            .SingleOrDefault();

        if (dangKyHoc == null)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNotExist
            );
        }

        _mapper.Map(updateDangKyHocDto, dangKyHoc);

        try
        {
            _context.Update(dangKyHoc);
            _context.SaveChanges();
        } catch
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.UpdateDataFailed
            );
        }

        KhoaHoc? khoaHoc = _context
            .KhoaHoc?.Where(x => x.KhoaHocId == dangKyHoc.KhoaHocId)
            .SingleOrDefault();

        if (khoaHoc == null)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNull
            );
        }

        dangKyHoc.NgayKetThuc = new DateTime(
            dangKyHoc.NgayBatDau!.Value.Year,
            dangKyHoc.NgayBatDau.Value.Month,
            dangKyHoc.NgayBatDau.Value.Day
        ).AddMonths((int) khoaHoc.ThoiGianHoc!);

        _context.Update(dangKyHoc);
        _context.SaveChanges();

        return _responses.StatusMessages(
            ResponsesStatus.Success,
            ResponsesMessages.UpdateDataSuccess
        );
    }

    public IResponses DeleteDangKyHoc(DeleteDangKyHocDto deleteDangKyHocDto)
    {

        DangKyHoc? dangKyHoc = _context
            .DangKyHoc?
            .Where(x => x.DangKyHocId == deleteDangKyHocDto.DangKyHocId)
            .SingleOrDefault();

        if (dangKyHoc == null)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNotExist
            );
        }

        KhoaHoc? khoaHoc = _context
            .KhoaHoc?.Where(x => x.KhoaHocId == dangKyHoc.KhoaHocId)
            .SingleOrDefault();

        if (khoaHoc == null)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNull
            );
        }

        khoaHoc.SoHocVien -= 1;

        _context.Update(khoaHoc);
        _context.SaveChanges();

        try
        {
            _context.Remove(dangKyHoc);
            _context.SaveChanges();
        } catch
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

    public IResponses GetDangKyHoc(int page, int pageSize)
    {
        List<DangKyHoc> dangKyHocs = _context.DangKyHoc!.ToList();

        if (dangKyHocs.Count == 0)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNull
            );
        }

        List<DangKyHoc> dangKyHocPaginations = PaginationHelper<DangKyHoc>.Pagination(
            dangKyHocs,
            page,
            pageSize
        );

        List<GetDangKyHocDto> getDangKyHocDtos = _mapper.Map<
            List<DangKyHoc>,
            List<GetDangKyHocDto>
        >(dangKyHocPaginations);

        return _responses.StatusMessagesData(
            ResponsesStatus.Success,
            ResponsesMessages.GetDataSuccess,
            getDangKyHocDtos
        );
    }
}
