using Dtos.TinhTrangHoc;
using Interfaces.IPayloads;

namespace Interfaces.IServices;

public interface ITinhTrangHocService
{
    public IResponses CreateTinhTrangHoc(
        CreateTinhTrangHocDto createTinhTrangHocDto
    );
    public IResponses UpdateTinhTrangHoc(
        UpdateTinhTrangHocDto updateTinhTrangHocDto
    );
    public IResponses DeleteTinhTrangHoc(
        DeleteTinhTrangHocDto deleteTinhTrangHocDto
    );
    public IResponses GetTinhTrangHoc();
}
