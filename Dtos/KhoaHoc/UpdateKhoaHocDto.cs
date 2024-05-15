using System.ComponentModel.DataAnnotations;

namespace Dtos;

public class UpdateKhoaHocDto
{
    [Required]
    public int KhoaHocId { get; set; }

    [MaxLength(50, ErrorMessage = "Tên khóa học không được quá 50 ký tự")]
    public string? TenKhoaHoc { get; set; }

    public int? ThoiGianHoc { get; set; }

    public string? GioiThieu { get; set; }

    public string? NoiDung { get; set; }

    public float? HocPhi { get; set; }

    public int? SoHocVien { get; set; }

    public int? SoLuongMon { get; set; }

    public string? HinhAnh { get; set; }

    public int? LoaiKhoaHocId { get; set; }
}
