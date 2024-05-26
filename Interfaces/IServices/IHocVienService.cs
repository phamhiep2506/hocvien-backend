using Dtos.HocVien;
using Interfaces.IPayloads;

namespace Interfaces.IServices;

public interface IHocVienService
{
    public IResponses CreateHocVien(CreateHocVienDto createHocVienDto);

    public IResponses UpdateHocVien(UpdateHocVienDto updateHocVienDto);
}
