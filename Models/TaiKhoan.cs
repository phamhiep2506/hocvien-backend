using System.ComponentModel.DataAnnotations;

namespace Models;

public class TaiKhoan
{
    [Key]
    public int TaiKhoanId { get; set; }

    [MaxLength(50)]
    public string? TenNguoiDung { get; set; }

    [MaxLength(50)]
    public string? TenDangNhap { get; set; }

    [MaxLength(50)]
    public string? MatKhau { get; set; }

    public int QuyenHanId { get; set; }

    public QuyenHan? QuyenHan { get; set; }

    public ICollection<DangKyHoc>? DangKyHocs { get; set; }

    public ICollection<BaiViet>? BaiViets { get; set; }
}
