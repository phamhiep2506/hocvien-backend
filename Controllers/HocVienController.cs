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

    [HttpPatch]
    public IActionResult UpdateHocVien(UpdateHocVienDto updateHocVienDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.UpdateHocVien(updateHocVienDto));
    }

    [HttpDelete]
    public IActionResult DeleteHocVien(DeleteHocVienDto deleteHocVienDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.DeleteHocVien(deleteHocVienDto));
    }

    [HttpGet]
    public IActionResult GetHocVien(int page, int pageSize)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.GetHocVien(page, page));
    }
}
