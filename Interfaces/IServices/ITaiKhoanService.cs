using Dtos.TaiKhoan;
using Interfaces.IPayloads;

namespace Interfaces.IServices;

public interface ITaiKhoanService
{
    public IResponses CreateTaiKhoan(CreateTaiKhoanDto createTaiKhoanDto);
    public IResponses UpdateTaiKhoan(UpdateTaiKhoanDto updateTaiKhoanDto);
    public IResponses DeleteTaiKhoan(DeleteTaiKhoanDto deleteTaiKhoanDto);
    public IResponses GetTaiKhoan(string tenDangNhap, int page, int pageSize);
}
