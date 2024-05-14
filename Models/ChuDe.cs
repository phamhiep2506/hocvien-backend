using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class ChuDe
{
    [Key]
    public int ChuDeId { get; set; }

    [MaxLength(50)]
    public string? TenChuDe { get; set; }

    [Column(TypeName = "nvarchar(MAX)")]
    [MaxLength]
    public string? NoiDung { get; set; }

    public LoaiBaiViet? LoaiBaiViet { get; set; }

    public ICollection<BaiViet>? BaiViets { get; set; }
}
