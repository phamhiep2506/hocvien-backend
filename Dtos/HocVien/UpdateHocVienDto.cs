using System.ComponentModel.DataAnnotations;

namespace Dtos.HocVien;

public class UpdateHocVienDto()
{
    [Required]
    public int HocVienId { get; set; }

    [MaxLength(50, ErrorMessage = "Họ tên không được quá 50 ký tự")]
    public string? HoTen { get; set; }

    public DateTime? NgaySinh { get; set; }

    [MaxLength(11, ErrorMessage = "Số điện thoại không được quá 11 ký tự")]
    [RegularExpression(
        @"(84|0[3|5|7|8|9])+([0-9]{8})\b",
        ErrorMessage = "Số điện thoại không hợp lệ"
    )]
    public string? SoDienThoai { get; set; }

    [MaxLength(40, ErrorMessage = "Email không được quá 40 ký tự")]
    [RegularExpression(
        @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",
        ErrorMessage = "Email không hợp lệ"
    )]
    public string? Email { get; set; }

    [MaxLength(50, ErrorMessage = "Tỉnh thành không được quá 50 ký tự")]
    public string? TinhThanh { get; set; }

    [MaxLength(50, ErrorMessage = "Quận huyện không được quá 50 ký tự")]
    public string? QuanHuyen { get; set; }

    [MaxLength(50, ErrorMessage = "Phường xã không được quá 50 ký tự")]
    public string? PhuongXa { get; set; }

    [MaxLength(50, ErrorMessage = "Số nhà không được quá 50 ký tự")]
    public string? SoNha { get; set; }
}
