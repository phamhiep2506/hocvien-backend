using AutoMapper;
using Dtos.QuyenHan;
using Interfaces.IPayloads;
using Interfaces.IServices;
using Models;
using Payloads;

namespace Services;

public class QuyenHanService : IQuyenHanService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly IResponses _responses;

    public QuyenHanService(
        IMapper mapper,
        ApplicationDbContext context,
        IResponses responses
    )
    {
        _mapper = mapper;
        _context = context;
        _responses = responses;
    }

    public IResponses CreateQuyenHan(CreateQuyenHanDto createQuyenHanDto)
    {
        if (
            _context.QuyenHan!.Any(x =>
                x.TenQuyenHan == createQuyenHanDto.TenQuyenHan
            )
        )
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataExisted
            );
        }

        QuyenHan quyenHan = _mapper.Map<CreateQuyenHanDto, QuyenHan>(
            createQuyenHanDto
        );

        try
        {
            _context.Add(quyenHan);
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
