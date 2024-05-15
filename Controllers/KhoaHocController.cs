using AutoMapper;
using Dtos.KhoaHoc;
using Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class KhoaHocController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<KhoaHocController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly IKhoaHocService _service;

    public KhoaHocController(
        IMapper mapper,
        ILogger<KhoaHocController> logger,
        ApplicationDbContext context,
        IKhoaHocService service
    )
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
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
}
