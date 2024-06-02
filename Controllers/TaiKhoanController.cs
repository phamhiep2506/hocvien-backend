using Dtos.TaiKhoan;
using Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaiKhoanController : ControllerBase
{
    private readonly ITaiKhoanService _service;

    public TaiKhoanController(ITaiKhoanService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreateTaiKhoan(CreateTaiKhoanDto createTaiKhoanDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.CreateTaiKhoan(createTaiKhoanDto));
    }

    [HttpPatch]
    public IActionResult UpdateTaiKhoan(UpdateTaiKhoanDto updateTaiKhoanDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.UpdateTaiKhoan(updateTaiKhoanDto));
    }

    [HttpDelete]
    public IActionResult DeleteTaiKhoan(DeleteTaiKhoanDto deleteTaiKhoanDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.DeleteTaiKhoan(deleteTaiKhoanDto));
    }

    [HttpGet]
    public IActionResult GetTaiKhoan(string tenDangNhap, int page, int pageSize)
    {
        return Ok(_service.GetTaiKhoan(tenDangNhap, page, pageSize));
    }
}
