using AutoMapper;
using Dtos;
using Interfaces.IPayloads;
using Interfaces.IServices;
using Models;
using Payloads;

namespace Services;

public class KhoaHocService : IKhoaHocService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly IResponses _responses;

    public KhoaHocService(
        IMapper mapper,
        ApplicationDbContext context,
        IResponses responses
    )
    {
        _mapper = mapper;
        _context = context;
        _responses = responses;
    }

    public IResponses CreateKhoaHoc(CreateKhoaHocDto createKhoaHocDto)
    {
        if (
            _context.KhoaHoc!.Any(x =>
                x.TenKhoaHoc == createKhoaHocDto.TenKhoaHoc
            )
        )
        {
            return _responses.StatusMessages(
                StatusCodes.Status202Accepted,
                ResponsesMessages.DataExisted
            );
        }

        KhoaHoc khoaHoc = _mapper.Map<CreateKhoaHocDto, KhoaHoc>(
            createKhoaHocDto
        );

        _context.Add(khoaHoc);
        _context.SaveChanges();

        return _responses.StatusMessages(
            StatusCodes.Status201Created,
            ResponsesMessages.CreateDataSuccess
        );
    }
}
