using AutoMapper;
using Dtos.QuyenHan;
using Helpers;
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

    public IResponses UpdateQuyenHan(UpdateQuyenHanDto updateQuyenHanDto)
    {
        QuyenHan? quyenHan = _context
            .QuyenHan?.Where(x => x.QuyenHanId == updateQuyenHanDto.QuyenHanId)
            .SingleOrDefault();

        if (quyenHan == null)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNotExist
            );
        }

        _mapper.Map(updateQuyenHanDto, quyenHan);

        try
        {
            _context.Update(quyenHan);
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

    public IResponses DeleteQuyenHan(DeleteQuyenHanDto deleteQuyenHanDto)
    {
        QuyenHan? quyenHan = _context
            .QuyenHan?.Where(x => x.QuyenHanId == deleteQuyenHanDto.QuyenHanId)
            .SingleOrDefault();

        if (quyenHan == null)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNotExist
            );
        }

        try
        {
            _context.Remove(quyenHan);
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

    public IResponses GetQuyenHan(int page, int pageSize)
    {
        List<QuyenHan> quyenHans = _context.QuyenHan!.ToList();

        if (quyenHans.Count == 0)
        {
            return _responses.StatusMessages(
                ResponsesStatus.Error,
                ResponsesMessages.DataNull
            );
        }

        List<QuyenHan> quyenHanPaginations =
            PaginationHelper<QuyenHan>.Pagination(quyenHans, page, pageSize);

        List<GetQuyenHanDto> getQuyenHanDtos = _mapper.Map<
            List<QuyenHan>,
            List<GetQuyenHanDto>
        >(quyenHanPaginations);

        return _responses.StatusMessagesData(
            ResponsesStatus.Success,
            ResponsesMessages.GetDataSuccess,
            getQuyenHanDtos
        );
    }
}
