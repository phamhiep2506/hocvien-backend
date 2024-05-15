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

        try
        {
            _context.Add(khoaHoc);
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

    public IResponses UpdateKhoaHoc(UpdateKhoaHocDto updateKhoaHocDto)
    {
        KhoaHoc? khoaHoc = _context
            .KhoaHoc?.Where(x => x.KhoaHocId == updateKhoaHocDto.KhoaHocId)
            .SingleOrDefault();

        if (khoaHoc == null)
        {
            return _responses.StatusMessages(
                StatusCodes.Status202Accepted,
                ResponsesMessages.DataNotExist
            );
        }

        _mapper.Map<UpdateKhoaHocDto, KhoaHoc>(updateKhoaHocDto, khoaHoc);

        try
        {
            _context.Update(khoaHoc);
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
}
