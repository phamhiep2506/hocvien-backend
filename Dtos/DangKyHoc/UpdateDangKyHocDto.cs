using System.ComponentModel.DataAnnotations;

namespace Dtos.DangKyHoc;

public class UpdateDangKyHocDto()
{
    [Required]
    public int DangKyHocId { get; set; }

    public int? KhoaHocId { get; set; }

    public int? HocVienId { get; set; }

    public DateTime? NgayDangKy { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public int? TinhTrangHocId { get; set; }

    public int? TaiKhoanId { get; set; }
}
