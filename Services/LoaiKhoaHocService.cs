using AutoMapper;
using Dtos.LoaiKhoaHoc;
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
}
