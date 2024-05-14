using System.ComponentModel.DataAnnotations;

namespace Models;

public class LoaiKhoaHoc
{
    [Key]
    public int LoaiKhoaHocId { get; set; }

    [MaxLength(30)]
    public string? TenLoai { get; set; }

    public ICollection<KhoaHoc>? KhoaHocs { get; set; }
}
