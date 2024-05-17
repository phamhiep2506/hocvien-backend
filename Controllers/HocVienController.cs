using Dtos.HocVien;
using Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class HocVienController : ControllerBase
{
    private readonly IHocVienService _service;

    public HocVienController(IHocVienService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreateHocVien(CreateHocVienDto createHocVienDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.CreateHocVien(createHocVienDto));
    }
}
