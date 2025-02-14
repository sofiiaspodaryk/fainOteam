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

    // GET: /fainoteam/getPaintingById/{id}
    [HttpGet("getPaintingById/{id}")]
    public async Task<IActionResult> GetPaintingById([FromRoute] int id)
    {
        var paintingDto = await galleryRepository.GetByIdAsync(id);

        if (paintingDto == null)
            return NotFound(new { message = "Painting not found" });

        return Ok(paintingDto);
    }

    // GET: /fainoteam/getAllPainting/
    [HttpGet("getAllPainting")]
    public async Task<IActionResult> GetAllPaintings(
                                    [FromBody] int? year_from,
                                    [FromBody] int? year_to,
                                    [FromBody] string? painting_name,
                                    [FromBody] string? movement_name,
                                    [FromBody] string? genre_name)
    {
        var paintingsDto = await galleryRepository
                                .GetAllAsync(year_from, year_to, painting_name, movement_name, genre_name);

        return Ok(paintingsDto);
    }
}
