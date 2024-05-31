using Dtos.DangKyHoc;
using Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class DangKyHocController : ControllerBase
{
    private readonly IDangKyhocService _service;

    public DangKyHocController(IDangKyhocService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreateDangKyHoc(CreateDangKyHocDto createDangKyHocDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.CreateDangKyHoc(createDangKyHocDto));
    }
}
