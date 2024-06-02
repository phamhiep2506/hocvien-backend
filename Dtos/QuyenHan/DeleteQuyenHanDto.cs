using System.ComponentModel.DataAnnotations;

namespace Dtos.QuyenHan;

public class DeleteQuyenHanDto
{
    [Required]
    public int QuyenHanId { get; set; }
}
