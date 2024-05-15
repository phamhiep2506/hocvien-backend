using Dtos.LoaiKhoaHoc;
using Interfaces.IPayloads;

namespace Interfaces.IServices;

public interface ILoaiKhoaHocService
{
    public IResponses CreateLoaiKhoaHoc(
        CreateLoaiKhoaHocDto createLoaiKhoaHocDto
    );

    public IResponses UpdateLoaiKhoaHoc(
        UpdateLoaiKhoaHocDto updateLoaiKhoaHocDto
    );

    public IResponses DeleteLoaiKhoaHoc(
        DeleteLoaiKhoaHocDto deleteLoaiKhoaHocDto
    );

    public IResponses GetLoaiKhoaHoc();
}
