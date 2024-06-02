using AutoMapper;
using Dtos.TaiKhoan;
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
}
