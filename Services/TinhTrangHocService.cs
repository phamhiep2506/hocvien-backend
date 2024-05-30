using AutoMapper;
using Dtos.TinhTrangHoc;
using Interfaces.IPayloads;
using Interfaces.IServices;
using Models;
using Payloads;

namespace Services;

public class TinhTrangHocService : ITinhTrangHocService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly IResponses _responses;

    public TinhTrangHocService(
        IMapper mapper,
        ApplicationDbContext context,
        IResponses responses
    )
    {
        _mapper = mapper;
        _context = context;
        _responses = responses;
    }

    public IResponses CreateTinhTrangHoc(
        CreateTinhTrangHocDto createTinhTrangHocDto
    )
    {
        if (
            _context.TinhTrangHoc!.Any(x =>
                x.TenTinhTrang == createTinhTrangHocDto.TenTinhTrang
            )
        )
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataExisted
            );
        }

        TinhTrangHoc tinhTrangHoc = _mapper.Map<
            CreateTinhTrangHocDto,
            TinhTrangHoc
        >(createTinhTrangHocDto);

        try
        {
            _context.Add(tinhTrangHoc);
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

    public IResponses UpdateTinhTrangHoc(
        UpdateTinhTrangHocDto updateTinhTrangHocDto
    )
    {
        TinhTrangHoc? tinhTrangHoc = _context
            .TinhTrangHoc?.Where(x =>
                x.TinhTrangHocId == updateTinhTrangHocDto.TinhTrangHocId
            )
            .SingleOrDefault();

        if (tinhTrangHoc == null)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNotExist
            );
        }

        _mapper.Map(updateTinhTrangHocDto, tinhTrangHoc);

        try
        {
            _context.Update(tinhTrangHoc);
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

    public IResponses DeleteTinhTrangHoc(
        DeleteTinhTrangHocDto deleteTinhTrangHocDto
    )
    {
        TinhTrangHoc? tinhTrangHoc = _context
            .TinhTrangHoc?.Where(x =>
                x.TinhTrangHocId == deleteTinhTrangHocDto.TinhTrangHocId
            )
            .SingleOrDefault();

        if (tinhTrangHoc == null)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNotExist
            );
        }

        try
        {
            _context.Remove(tinhTrangHoc);
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

    public IResponses GetTinhTrangHoc()
    {
        IEnumerable<TinhTrangHoc> tinhTrangHocs =
            _context.TinhTrangHoc!.ToList();

        if (tinhTrangHocs.Count() == 0)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNull
            );
        }

        return _responses.StatusMessagesData(
            ResponsesStatus.Success,
            ResponsesMessages.GetDataSuccess,
            _mapper.Map<
                IEnumerable<TinhTrangHoc>,
                IEnumerable<GetTinhTrangHocDto>
            >(tinhTrangHocs)
        );
    }
}
