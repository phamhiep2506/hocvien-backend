using System.ComponentModel.DataAnnotations;

namespace Dtos.TinhTrangHoc;

public class DeleteTinhTrangHocDto()
{
    [Required]
    public int TinhTrangHocId { get; set; }
}
