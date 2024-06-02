using Dtos.TaiKhoan;
using Interfaces.IPayloads;

namespace Interfaces.IServices;

public interface ITaiKhoanService
{
    public IResponses CreateTaiKhoan(CreateTaiKhoanDto createTaiKhoanDto);
}
