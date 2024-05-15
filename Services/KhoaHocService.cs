using AutoMapper;
using Dtos.KhoaHoc;
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
                ResponsesStatus.Error,
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
                ResponsesStatus.Error,
                ResponsesMessages.CreateDataFailed
            );
        }

        return _responses.StatusMessages(
            ResponsesStatus.Success,
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
                ResponsesStatus.Error,
                ResponsesMessages.DataNotExist
            );
        }

        _mapper.Map(updateKhoaHocDto, khoaHoc);

        try
        {
            _context.Update(khoaHoc);
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

    public IResponses DeleteKhoaHoc(DeleteKhoaHocDto deleteKhoaHocDto)
    {
        KhoaHoc? khoaHoc = _context
            .KhoaHoc?.Where(x => x.KhoaHocId == deleteKhoaHocDto.KhoaHocId)
            .SingleOrDefault();

        if (khoaHoc == null)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNotExist
            );
        }

        try
        {
            _context.Remove(khoaHoc);
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

    public IResponses GetKhoaHoc()
    {
        List<KhoaHoc> khoaHoc = _context.KhoaHoc!.ToList();

        if (khoaHoc.Count == 0)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNull
            );
        }

        List<GetKhoaHocDto> getKhoaHocDtos = _mapper.Map<
            List<KhoaHoc>,
            List<GetKhoaHocDto>
        >(khoaHoc);

        return _responses.StatusMessagesData(
            ResponsesStatus.Success,
            ResponsesMessages.GetDataSuccess,
            getKhoaHocDtos
        );
    }

    public IResponses SearchKhoaHocByName(string tenKhoaHoc)
    {
        List<KhoaHoc> khoaHoc = _context
            .KhoaHoc!.Where(x => x.TenKhoaHoc == tenKhoaHoc)
            .ToList();

        if (khoaHoc.Count == 0)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNull
            );
        }

        List<GetKhoaHocDto> getKhoaHocDtos = _mapper.Map<
            List<KhoaHoc>,
            List<GetKhoaHocDto>
        >(khoaHoc);

        return _responses.StatusMessagesData(
            ResponsesStatus.Success,
            ResponsesMessages.GetDataSuccess,
            getKhoaHocDtos
        );
    }
}
