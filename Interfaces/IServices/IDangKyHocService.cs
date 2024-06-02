using Dtos.DangKyHoc;
using Interfaces.IPayloads;

namespace Interfaces.IServices;

public interface IDangKyhocService
{
    public IResponses CreateDangKyHoc(CreateDangKyHocDto createDangKyHocDto);
    public IResponses UpdateDangKyHoc(UpdateDangKyHocDto updateDangKyHocDto);
    public IResponses DeleteDangKyHoc(DeleteDangKyHocDto DeleteDangKyHocDto);
    public IResponses GetDangKyHoc(int page, int pageSize);
}
