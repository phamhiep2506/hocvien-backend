using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class KhoaHoc
{
    [Key]
    public int KhoaHocId { get; set; }

    [MaxLength(50)]
    public string? TenKhoaHoc { get; set; }

    public int ThoiGianHoc { get; set; }

    [Column(TypeName = "nvarchar(MAX)")]
    [MaxLength]
    public string? GioiThieu { get; set; }

    [Column(TypeName = "nvarchar(MAX)")]
    [MaxLength]
    public string? NoiDung { get; set; }

    public float HocPhi { get; set; }

    public int SoHocVien { get; set; }

    public int SoLuongMon { get; set; }

    [Column(TypeName = "nvarchar(MAX)")]
    [MaxLength]
    public string? HinhAnh { get; set; }

    public int LoaiKhoaHocId { get; set; }

    public LoaiKhoaHoc? LoaiKhoaHoc { get; set; }

    public ICollection<DangKyHoc>? DangKyHocs { get; set; }
}
