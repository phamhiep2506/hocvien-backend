using System.ComponentModel.DataAnnotations;

namespace Dtos.LoaiKhoaHoc;

public class UpdateLoaiKhoaHocDto
{
    [Required]
    public int LoaiKhoaHocId { get; set; }

    [Required]
    [MaxLength(30, ErrorMessage = "Tên loại không được quá 30 ký tự")]
    public string? TenLoai { get; set; }
}
