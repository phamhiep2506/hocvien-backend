using Dtos.QuyenHan;
using Interfaces.IPayloads;

namespace Interfaces.IServices;

public interface IQuyenHanService
{
    public IResponses CreateQuyenHan(CreateQuyenHanDto createQuyenHanDto);
    public IResponses UpdateQuyenHan(UpdateQuyenHanDto updateQuyenHanDto);
    public IResponses DeleteQuyenHan(DeleteQuyenHanDto deleteQuyenHanDto);
    public IResponses GetQuyenHan(int page, int pageSize);
}
