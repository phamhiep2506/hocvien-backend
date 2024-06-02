using System.ComponentModel.DataAnnotations;

namespace Dtos.TaiKhoan;

public class DeleteTaiKhoanDto
{
    [Required]
    public int TaiKhoanId { get; set; }
}
