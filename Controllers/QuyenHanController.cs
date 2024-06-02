using Dtos.QuyenHan;
using Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuyenHanController : ControllerBase
{
    private readonly IQuyenHanService _service;

    public QuyenHanController(IQuyenHanService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreateQuyenHan(CreateQuyenHanDto createQuyenHanDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.CreateQuyenHan(createQuyenHanDto));
    }
}
