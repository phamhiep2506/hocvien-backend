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

    [HttpPatch]
    public IActionResult UpdateQuyenHan(UpdateQuyenHanDto updateQuyenHanDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.UpdateQuyenHan(updateQuyenHanDto));
    }

    [HttpDelete]
    public IActionResult DeleteQuyenHan(DeleteQuyenHanDto deleteQuyenHanDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.DeleteQuyenHan(deleteQuyenHanDto));
    }

    [HttpGet]
    public IActionResult GetQuyenHan(int page, int pageSize)
    {
        return Ok(_service.GetQuyenHan(page, pageSize));
    }
}
