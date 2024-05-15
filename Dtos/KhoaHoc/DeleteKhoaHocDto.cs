using System.ComponentModel.DataAnnotations;

namespace Dtos.KhoaHoc;

public class DeleteKhoaHocDto
{
    [Required]
    public int KhoaHocId { get; set; }
}
