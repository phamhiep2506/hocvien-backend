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

    [HttpPatch]
    public IActionResult UpdateDangKyHoc(UpdateDangKyHocDto updateDangKyHocDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.UpdateDangKyHoc(updateDangKyHocDto));
    }

    [HttpDelete]
    public IActionResult DeleteDangKyHoc(DeleteDangKyHocDto deleteDangKyHocDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.DeleteDangKyHoc(deleteDangKyHocDto));
    }

    [HttpGet]
    public IActionResult GetDangKyHoc(int page, int pageSize)
    {
        return Ok(_service.GetDangKyHoc(page, pageSize));
    }
}
