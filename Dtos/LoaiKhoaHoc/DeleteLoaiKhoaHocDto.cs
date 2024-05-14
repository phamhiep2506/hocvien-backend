using System.ComponentModel.DataAnnotations;

namespace Dtos.LoaiKhoaHoc;

public class DeleteLoaiKhoaHocDto
{
    [Required]
    public int LoaiKhoaHocId { get; set; }
}
