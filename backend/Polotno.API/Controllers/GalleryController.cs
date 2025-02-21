using Microsoft.AspNetCore.Mvc;
using Polotno.API.Repositories;

namespace Polotno.API.Controllers;

[ApiController]
[Route("fainoteam")]
public class GalleryController : ControllerBase
{
    private readonly IGalleryRepository galleryRepository;

    public GalleryController(IGalleryRepository galleryRepository)
    {
        this.galleryRepository = galleryRepository;
    }

    // GET: /fainoteam/paintings/{id}
    [HttpGet("paintings/{id}")]
    public async Task<IActionResult> GetPaintingById([FromRoute] int id)
    {
        var paintingDto = await galleryRepository.GetByIdAsync(id);

        if (paintingDto == null)
            return NotFound(new { message = "Painting not found" });

        return Ok(paintingDto);
    }

    // GET: /fainoteam/paintings/
    [HttpGet("paintings")]
    public async Task<IActionResult> GetAllPaintings()
    {
        var paintingsDto = await galleryRepository.GetAllAsync();

        return Ok(paintingsDto);
    }
}
