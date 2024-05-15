using Dtos;
using Interfaces.IPayloads;

namespace Interfaces.IServices;

public interface IKhoaHocService
{
    public IResponses CreateKhoaHoc(CreateKhoaHocDto createKhoaHocDto);
}
