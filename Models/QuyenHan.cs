using System.ComponentModel.DataAnnotations;

namespace Models;

public class QuyenHan
{
    [Key]
    public int QuyenHanId { get; set; }

    [MaxLength(50)]
    public string? TenQuyenHan { get; set; }

    public ICollection<TaiKhoan>? TaiKhoans { get; set; }
}
