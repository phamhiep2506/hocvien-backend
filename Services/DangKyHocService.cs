using AutoMapper;
using Dtos.DangKyHoc;
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

        _context.Update(khoaHoc);
        _context.SaveChanges();

        return _responses.StatusMessages(
            ResponsesStatus.Success,
            ResponsesMessages.CreateDataSuccess
        );
    }
}
