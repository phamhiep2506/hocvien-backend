using AutoMapper;
using Dtos.LoaiKhoaHoc;
using Microsoft.EntityFrameworkCore;
using Models;
using Payloads;
using Services.IServices;

namespace Services;

public class LoaiKhoaHocService : ILoaiKhoaHocService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public LoaiKhoaHocService(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public Responses CreateLoaiKhoaHoc(
        CreateLoaiKhoaHocDto createLoaiKhoaHocDto
    )
    {
        if (
            _context.LoaiKhoaHoc!.Any(x =>
                x.TenLoai == createLoaiKhoaHocDto.TenLoai
            )
        )
        {
            return new Responses().StatusMessages(
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

        return new Responses().StatusMessages(
            201,
            "Loại khóa học được thêm thành công"
        );
    }

    public Responses UpdateLoaiKhoaHoc(
        UpdateLoaiKhoaHocDto updateLoaiKhoaHocDto
    )
    {
        LoaiKhoaHoc? loaiKhoaHoc = _context
            .LoaiKhoaHoc?.AsNoTracking()
            .Where(x => x.LoaiKhoaHocId == updateLoaiKhoaHocDto.LoaiKhoaHocId)
            .SingleOrDefault();

        if (loaiKhoaHoc == null)
        {
            return new Responses().StatusMessages(
                202,
                "Loại khóa học không tồn tại"
            );
        }

        loaiKhoaHoc = _mapper.Map<UpdateLoaiKhoaHocDto, LoaiKhoaHoc>(
            updateLoaiKhoaHocDto
        );

        _context.Update(loaiKhoaHoc);
        _context.SaveChanges();

        return new Responses().StatusMessages(
            200,
            "Sửa loại khóa học thành công"
        );
    }

    public Responses DeleteLoaiKhoaHoc(
        DeleteLoaiKhoaHocDto deleteLoaiKhoaHocDto
    )
    {
        LoaiKhoaHoc? loaiKhoaHoc = _context
            .LoaiKhoaHoc?.AsNoTracking()
            .Where(x => x.LoaiKhoaHocId == deleteLoaiKhoaHocDto.LoaiKhoaHocId)
            .SingleOrDefault();

        if (loaiKhoaHoc == null)
        {
            return new Responses().StatusMessages(
                202,
                "Loại khóa học không tồn tại"
            );
        }

        _context.Remove(loaiKhoaHoc);
        _context.SaveChanges();

        return new Responses().StatusMessages(
            200,
            "Xóa loại khóa học thành công"
        );
    }
}
