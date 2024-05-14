using System.ComponentModel.DataAnnotations;

namespace Models;

public class TinhTrangHoc
{
    [Key]
    public int TinhTrangHocId { get; set; }

    [MaxLength(40)]
    public string? TenTinhTrang { get; set; }

    public ICollection<DangKyHoc>? DangKyHocs { get; set; }
}
