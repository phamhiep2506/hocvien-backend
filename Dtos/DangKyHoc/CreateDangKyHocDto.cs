using System.ComponentModel.DataAnnotations;

namespace Dtos.DangKyHoc;

public class CreateDangKyHocDto()
{
    [Required]
    public int KhoaHocId { get; set; }

    [Required]
    public int HocVienId { get; set; }

    [Required]
    public DateTime NgayDangKy { get; set; }

    [Required]
    public DateTime NgayBatDau { get; set; }

    [Required]
    public int TinhTrangHocId { get; set; }

    [Required]
    public int TaiKhoanId { get; set; }
}
