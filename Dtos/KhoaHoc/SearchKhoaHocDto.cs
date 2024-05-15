using System.ComponentModel.DataAnnotations;

namespace Dtos.KhoaHoc;

public class SearchKhoaHocDto
{
    [Required]
    [MaxLength(50, ErrorMessage = "Tên khóa học không được quá 50 ký tự")]
    public string? TenKhoaHoc { get; set; }
}
