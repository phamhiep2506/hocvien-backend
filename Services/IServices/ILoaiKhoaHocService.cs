using Dtos.LoaiKhoaHoc;
using Payloads;

namespace Services.IServices;

public interface ILoaiKhoaHocService
{
    public Responses CreateLoaiKhoaHoc(
        CreateLoaiKhoaHocDto createLoaiKhoaHocDto
    );
}
