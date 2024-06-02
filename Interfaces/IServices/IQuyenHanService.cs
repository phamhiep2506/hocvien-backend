using Dtos.QuyenHan;
using Interfaces.IPayloads;

namespace Interfaces.IServices;

public interface IQuyenHanService
{
    public IResponses CreateQuyenHan(CreateQuyenHanDto createQuyenHanDto);
}
