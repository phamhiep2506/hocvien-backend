using Dtos.TinhTrangHoc;
using Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class TinhTrangHocController : ControllerBase
{
    private readonly ITinhTrangHocService _service;

    public TinhTrangHocController(ITinhTrangHocService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreateTinhTrangHoc(
        CreateTinhTrangHocDto createTinhTrangHocDto
    )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.CreateTinhTrangHoc(createTinhTrangHocDto));
    }

    [HttpPatch]
    public IActionResult UpdateTinhTrangHoc(
        UpdateTinhTrangHocDto updateTinhTrangHocDto
    )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.UpdateTinhTrangHoc(updateTinhTrangHocDto));
    }

    [HttpDelete]
    public IActionResult DeleteTinhTrangHoc(
        DeleteTinhTrangHocDto deleteTinhTrangHocDto
    )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.DeleteTinhTrangHoc(deleteTinhTrangHocDto));
    }

    [HttpGet]
    public IActionResult GetTinhTrangHoc()
    {
        return Ok(_service.GetTinhTrangHoc());
    }
}
