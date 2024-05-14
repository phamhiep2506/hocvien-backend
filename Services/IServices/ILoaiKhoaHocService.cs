using Dtos.LoaiKhoaHoc;
using Payloads;

namespace Services.IServices;

public interface ILoaiKhoaHocService
{
    public Responses CreateLoaiKhoaHoc(
        CreateLoaiKhoaHocDto createLoaiKhoaHocDto
    );

    public Responses UpdateLoaiKhoaHoc(
        UpdateLoaiKhoaHocDto updateLoaiKhoaHocDto
    );

    public Responses DeleteLoaiKhoaHoc(
        DeleteLoaiKhoaHocDto deleteLoaiKhoaHocDto
    );
}
