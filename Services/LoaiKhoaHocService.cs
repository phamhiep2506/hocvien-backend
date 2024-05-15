using AutoMapper;
using Dtos.LoaiKhoaHoc;
using Microsoft.EntityFrameworkCore;
using Models;
using Interfaces.IServices;
using Interfaces.IPayloads;

namespace Services;

public class LoaiKhoaHocService : ILoaiKhoaHocService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly IResponses _responses;

    public LoaiKhoaHocService(
        IMapper mapper,
        ApplicationDbContext context,
        IResponses responses
    )
    {
        _mapper = mapper;
        _context = context;
        _responses = responses;
    }

    public IResponses CreateLoaiKhoaHoc(
        CreateLoaiKhoaHocDto createLoaiKhoaHocDto
    )
    {
        if (
            _context.LoaiKhoaHoc!.Any(x =>
                x.TenLoai == createLoaiKhoaHocDto.TenLoai
            )
        )
        {
            return _responses.StatusMessages(
                202,
                "Loại khóa học đã tồn tại"
            );
        }

        LoaiKhoaHoc loaiKhoaHoc = _mapper.Map<
            CreateLoaiKhoaHocDto,
            LoaiKhoaHoc
        >(createLoaiKhoaHocDto);

        _context.Add(loaiKhoaHoc);
        _context.SaveChanges();

        return _responses.StatusMessages(
            201,
            "Loại khóa học được thêm thành công"
        );
    }

    public IResponses UpdateLoaiKhoaHoc(
        UpdateLoaiKhoaHocDto updateLoaiKhoaHocDto
    )
    {
        LoaiKhoaHoc? loaiKhoaHoc = _context
            .LoaiKhoaHoc?.AsNoTracking()
            .Where(x => x.LoaiKhoaHocId == updateLoaiKhoaHocDto.LoaiKhoaHocId)
            .SingleOrDefault();

        if (loaiKhoaHoc == null)
        {
            return _responses.StatusMessages(
                202,
                "Loại khóa học không tồn tại"
            );
        }

        loaiKhoaHoc = _mapper.Map<UpdateLoaiKhoaHocDto, LoaiKhoaHoc>(
            updateLoaiKhoaHocDto
        );

        _context.Update(loaiKhoaHoc);
        _context.SaveChanges();

        return _responses.StatusMessages(
            200,
            "Sửa loại khóa học thành công"
        );
    }

    public IResponses DeleteLoaiKhoaHoc(
        DeleteLoaiKhoaHocDto deleteLoaiKhoaHocDto
    )
    {
        LoaiKhoaHoc? loaiKhoaHoc = _context
            .LoaiKhoaHoc?.AsNoTracking()
            .Where(x => x.LoaiKhoaHocId == deleteLoaiKhoaHocDto.LoaiKhoaHocId)
            .SingleOrDefault();

        if (loaiKhoaHoc == null)
        {
            return _responses.StatusMessages(
                202,
                "Loại khóa học không tồn tại"
            );
        }

        _context.Remove(loaiKhoaHoc);
        _context.SaveChanges();

        return _responses.StatusMessages(
            200,
            "Xóa loại khóa học thành công"
        );
    }
}
