using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class HocVien
{
    [Key]
    public int HocVienId { get; set; }

    [Column(TypeName = "nvarchar(MAX)")]
    [MaxLength]
    public string? HinhAnh { get; set; }

    [MaxLength(50)]
    public string? HoTen { get; set; }

    public DateTime NgaySinh { get; set; }

    [MaxLength(11)]
    public string? SoDienThoai { get; set; }

    [MaxLength(40)]
    public string? Email { get; set; }

    [MaxLength(50)]
    public string? TinhThanh { get; set; }

    [MaxLength(50)]
    public string? QuanHuyen { get; set; }

    [MaxLength(50)]
    public string? PhuongXa { get; set; }

    [MaxLength(50)]
    public string? SoNha { get; set; }

    public ICollection<DangKyHoc>? DangKyHocs { get; set; }
}
