using AutoMapper;
using Dtos.HocVien;
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
}
