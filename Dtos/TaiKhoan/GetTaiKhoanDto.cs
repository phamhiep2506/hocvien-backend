namespace Dtos.TaiKhoan;

public class GetTaiKhoanDto
{
    public int TaiKhoanId { get; set; }

    public string? TenNguoiDung { get; set; }

    public string? TenDangNhap { get; set; }

    public string? MatKhau { get; set; }

    public int QuyenHanId { get; set; }
}
