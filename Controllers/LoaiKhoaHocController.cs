using Dtos.LoaiKhoaHoc;
using Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoaiKhoaHocController : ControllerBase
{
    private readonly ILoaiKhoaHocService _service;

    public LoaiKhoaHocController(ILoaiKhoaHocService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreateLoaiKhoaHoc(
        CreateLoaiKhoaHocDto createLoaiKhoaHocDto
    )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.CreateLoaiKhoaHoc(createLoaiKhoaHocDto));
    }

    [HttpPatch]
    public IActionResult UpdateLoaiKhoaHoc(
        UpdateLoaiKhoaHocDto updateLoaiKhoaHocDto
    )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.UpdateLoaiKhoaHoc(updateLoaiKhoaHocDto));
    }

    [HttpDelete]
    public IActionResult DeleteLoaiKhoaHoc(
        DeleteLoaiKhoaHocDto deleteLoaiKhoaHocDto
    )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.DeleteLoaiKhoaHoc(deleteLoaiKhoaHocDto));
    }

    [HttpGet]
    public IActionResult GetLoaiKhoaHoc()
    {
        return Ok(_service.GetLoaiKhoaHoc());
    }
}
