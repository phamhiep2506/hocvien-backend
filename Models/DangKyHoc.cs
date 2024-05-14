using System.ComponentModel.DataAnnotations;

namespace Models;

public class DangKyHoc
{
    [Key]
    public int DangKyHocId { get; set; }

    public int KhoaHocId { get; set; }

    public int HocVienId { get; set; }

    public DateTime NgayDangKy { get; set; }

    public DateTime NgayBatDau { get; set; }

    public DateTime NgayKetThuc { get; set; }

    public int TinhTrangHocId { get; set; }

    public int TaiKhoanId { get; set; }

    public KhoaHoc? KhoaHoc { get; set; }

    public TinhTrangHoc? TinhTrangHoc { get; set; }

    public HocVien? HocVien { get; set; }

    public TaiKhoan? TaiKhoan { get; set; }
}
