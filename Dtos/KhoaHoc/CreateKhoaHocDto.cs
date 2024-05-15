using System.ComponentModel.DataAnnotations;

namespace Dtos;

public class CreateKhoaHocDto
{
    [Required]
    [MaxLength(50, ErrorMessage = "Tên khóa học không được quá 50 ký tự")]
    public string? TenKhoaHoc { get; set; }

    [Required]
    public int ThoiGianHoc { get; set; }

    [Required]
    public string? GioiThieu { get; set; }

    [Required]
    public string? NoiDung { get; set; }

    [Required]
    public float HocPhi { get; set; }

    [Required]
    public int SoHocVien { get; set; }

    [Required]
    public int SoLuongMon { get; set; }

    [Required]
    public string? HinhAnh { get; set; }

    [Required]
    public int LoaiKhoaHocId { get; set; }
}
