using AutoMapper;
using Dtos.LoaiKhoaHoc;
using Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoaiKhoaHocController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<LoaiKhoaHocController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly ILoaiKhoaHocService _service;

    public LoaiKhoaHocController(
        IMapper mapper,
        ILogger<LoaiKhoaHocController> logger,
        ApplicationDbContext context,
        ILoaiKhoaHocService service
    )
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
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

        return Ok(
            _service.CreateLoaiKhoaHoc(
                createLoaiKhoaHocDto
            )
        );
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

        return Ok(
            _service.UpdateLoaiKhoaHoc(
                updateLoaiKhoaHocDto
            )
        );
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

        return Ok(
            _service.DeleteLoaiKhoaHoc(deleteLoaiKhoaHocDto)
        );
    }
}
