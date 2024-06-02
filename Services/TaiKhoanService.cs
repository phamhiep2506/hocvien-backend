using AutoMapper;
using Dtos.TaiKhoan;
using Helpers;
using Interfaces.IPayloads;
using Interfaces.IServices;
using Models;
using Payloads;

namespace Services;

public class TaiKhoanService : ITaiKhoanService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly IResponses _responses;

    public TaiKhoanService(
        IMapper mapper,
        ApplicationDbContext context,
        IResponses responses
    )
    {
        _mapper = mapper;
        _context = context;
        _responses = responses;
    }

    public IResponses CreateTaiKhoan(CreateTaiKhoanDto createTaiKhoanDto)
    {
        if (
            _context.TaiKhoan!.Any(x =>
                x.TenDangNhap == createTaiKhoanDto.TenDangNhap
            )
        )
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataExisted
            );
        }

        TaiKhoan taiKhoan = _mapper.Map<CreateTaiKhoanDto, TaiKhoan>(
            createTaiKhoanDto
        );

        try
        {
            _context.Add(taiKhoan);
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

    public IResponses UpdateTaiKhoan(UpdateTaiKhoanDto updateTaiKhoanDto)
    {
        TaiKhoan? taiKhoan = _context
            .TaiKhoan?.Where(x => x.TaiKhoanId == updateTaiKhoanDto.TaiKhoanId)
            .SingleOrDefault();

        if (taiKhoan == null)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNotExist
            );
        }

        _mapper.Map(updateTaiKhoanDto, taiKhoan);

        try
        {
            _context.Update(taiKhoan);
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

    public IResponses DeleteTaiKhoan(DeleteTaiKhoanDto deleteTaiKhoanDto)
    {
        TaiKhoan? taiKhoan = _context
            .TaiKhoan?.Where(x => x.TaiKhoanId == deleteTaiKhoanDto.TaiKhoanId)
            .SingleOrDefault();

        if (taiKhoan == null)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNotExist
            );
        }

        List<DangKyHoc> dangKyHocs = _context
            .DangKyHoc!.Where(x => x.TaiKhoanId == taiKhoan.TaiKhoanId)
            .ToList();

        if (dangKyHocs.Count == 0)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNull
            );
        }

        dangKyHocs.ForEach(dangKyHoc =>
        {
            _context.Remove(dangKyHoc);
            _context.SaveChanges();
        });

        try
        {
            _context.Remove(taiKhoan);
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

    public IResponses GetTaiKhoan(string tenDangNhap, int page, int pageSize)
    {
        List<TaiKhoan> taiKhoans = _context
            .TaiKhoan!.Where(x => x.TenDangNhap!.Contains(tenDangNhap))
            .ToList();

        if (taiKhoans.Count == 0)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNull
            );
        }

        List<TaiKhoan> taiKhoanPaginations =
            PaginationHelper<TaiKhoan>.Pagination(taiKhoans, page, pageSize);

        List<GetTaiKhoanDto> getTaiKhoanDtos = _mapper.Map<
            List<TaiKhoan>,
            List<GetTaiKhoanDto>
        >(taiKhoanPaginations);

        return _responses.StatusMessagesData(
            ResponsesStatus.Success,
            ResponsesMessages.GetDataSuccess,
            getTaiKhoanDtos
        );
    }
}
