using System.ComponentModel.DataAnnotations;
using Dtos.KhoaHoc;
using Fakers;
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

        /*
            Generate data
        */
        // var faker = new KhoaHocFaker().Generate();
        // return Ok(_service.CreateKhoaHoc(faker));

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
    public IActionResult GetKhoaHoc(
        [Range(1, int.MaxValue)] [Required] int page,
        [Range(1, int.MaxValue)] [Required] int pageSize
    )
    {
        return Ok(_service.GetKhoaHoc(page, pageSize));
    }

    [HttpGet]
    [Route("search")]
    public IActionResult SearchKhoaHocByName(
        [MaxLength(50, ErrorMessage = "Tên khóa học không được quá 50 ký tự")]
        [Required]
            string tenKhoaHoc,
        [Range(1, int.MaxValue)] [Required] int page,
        [Range(1, int.MaxValue)] [Required] int pageSize
    )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_service.SearchKhoaHocByName(tenKhoaHoc, page, pageSize));
    }
}
