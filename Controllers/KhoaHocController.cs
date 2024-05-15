using Dtos.KhoaHoc;
using Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class KhoaHocController : ControllerBase
{
    private readonly IKhoaHocService _service;

    public KhoaHocController(IKhoaHocService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreateKhoaHoc(CreateKhoaHocDto createKhoaHocDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.CreateKhoaHoc(createKhoaHocDto));
    }

    [HttpPatch]
    public IActionResult UpdateKhoaHoc(UpdateKhoaHocDto updateKhoaHocDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.UpdateKhoaHoc(updateKhoaHocDto));
    }

    [HttpDelete]
    public IActionResult DeleteKhoaHoc(DeleteKhoaHocDto deleteKhoaHocDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.DeleteKhoaHoc(deleteKhoaHocDto));
    }

    [HttpGet]
    public IActionResult GetKhoaHoc()
    {
        return Ok(_service.GetKhoaHoc());
    }

    [HttpGet]
    [Route("search")]
    public IActionResult SearchKhoaHocByName(SearchKhoaHocDto searchKhoaHocDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.SearchKhoaHocByName(searchKhoaHocDto));
    }
}
