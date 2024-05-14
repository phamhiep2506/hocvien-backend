using AutoMapper;
using Dtos.LoaiKhoaHoc;
using Microsoft.AspNetCore.Mvc;
using Models;
using Payloads;
using Services;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoaiKhoaHocController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<LoaiKhoaHocController> _logger;
    private readonly ApplicationDbContext _context;

    public LoaiKhoaHocController(
        IMapper mapper,
        ILogger<LoaiKhoaHocController> logger,
        ApplicationDbContext context
    )
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
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
            new LoaiKhoaHocService(_mapper, _context).CreateLoaiKhoaHoc(
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
            new LoaiKhoaHocService(_mapper, _context).UpdateLoaiKhoaHoc(
                updateLoaiKhoaHocDto
            )
        );
    }
}
