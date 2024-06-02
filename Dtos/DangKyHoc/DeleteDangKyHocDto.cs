using System.ComponentModel.DataAnnotations;

namespace Dtos.DangKyHoc;

public class DeleteDangKyHocDto()
{
    [Required]
    public int DangKyHocId { get; set; }
}
