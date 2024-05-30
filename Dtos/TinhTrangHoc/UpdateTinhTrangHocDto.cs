using System.ComponentModel.DataAnnotations;

namespace Dtos.TinhTrangHoc;

public class UpdateTinhTrangHocDto()
{
    [Required]
    public int TinhTrangHocId { get; set; }

    [Required]
    [MaxLength(40, ErrorMessage = "Tên không được quá 40 kí tự")]
    public string? TenTinhTrang { get; set; }
}
