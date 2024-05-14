using System.ComponentModel.DataAnnotations;

namespace Models;

public class LoaiBaiViet
{
    [Key]
    public int LoaiBaiVietId { get; set; }

    [MaxLength(50)]
    public string? TenLoai { get; set; }

    public ICollection<ChuDe>? ChuDes { get; set; }
}
