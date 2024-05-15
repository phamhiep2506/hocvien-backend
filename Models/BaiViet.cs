using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class BaiViet
{
    public int BaiVietId { get; set; }

    [MaxLength(50)]
    public string? TenBaiViet { get; set; }

    [MaxLength(50)]
    public string? TenTacGia { get; set; }

    [Column(TypeName = "nvarchar(MAX)")]
    [MaxLength]
    public string? NoiDung { get; set; }

    [MaxLength(1000)]
    public string? NoiDungNgan { get; set; }

    public DateTime? ThoiGianTao { get; set; }

    [Column(TypeName = "nvarchar(MAX)")]
    [MaxLength]
    public string? HinhAnh { get; set; }

    public int? ChuDeId { get; set; }

    public int? TaiKhoanId { get; set; }

    public TaiKhoan? TaiKhoan { get; set; }

    public ChuDe? ChuDe { get; set; }
}
