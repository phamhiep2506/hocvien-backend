using System.ComponentModel.DataAnnotations;

namespace Dtos.QuyenHan;

public class UpdateQuyenHanDto
{
    [Required]
    public int QuyenHanId { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "Tên quyền hạn không được quá 50 ký tự")]
    public string? TenQuyenHan { get; set; }
}
