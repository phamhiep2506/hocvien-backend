using System.ComponentModel.DataAnnotations;

namespace Dtos.HocVien;

public class DeleteHocVienDto
{
    [Required]
    public int HocVienId { get; set; }
}
