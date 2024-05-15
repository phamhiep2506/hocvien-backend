using Dtos.KhoaHoc;
using Interfaces.IPayloads;

namespace Interfaces.IServices;

public interface IKhoaHocService
{
    public IResponses CreateKhoaHoc(CreateKhoaHocDto createKhoaHocDto);
    public IResponses UpdateKhoaHoc(UpdateKhoaHocDto updateKhoaHocDto);

    public IResponses DeleteKhoaHoc(DeleteKhoaHocDto deleteKhoaHocDto);

    public IResponses GetKhoaHoc();

    public IResponses SearchKhoaHocByName(SearchKhoaHocDto searchKhoaHocDto);
}
