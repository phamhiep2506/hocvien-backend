using System.ComponentModel.DataAnnotations;

namespace Dtos.TaiKhoan;

public class UpdateTaiKhoanDto
{
    [Required]
    public int TaiKhoanId { get; set; }

    [MaxLength(50, ErrorMessage = "Tên người dùng không được quá 50 ký tự")]
    public string? TenNguoiDung { get; set; }

    [MaxLength(50, ErrorMessage = "Tên đăng nhập không được quá 50 ký tự")]
    public string? TenDangNhap { get; set; }

    [MaxLength(50, ErrorMessage = "Mật khẩu không được quá 50 ký tự")]
    public string? MatKhau { get; set; }

    public int? QuyenHanId { get; set; }
}
