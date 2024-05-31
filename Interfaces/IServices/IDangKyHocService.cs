using Dtos.DangKyHoc;
using Interfaces.IPayloads;

namespace Interfaces.IServices;

public interface IDangKyhocService
{
    public IResponses CreateDangKyHoc(CreateDangKyHocDto createDangKyHocDto);
}
