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

    // GET: /fainoteam/getAllPaintings/
    [HttpGet("getAllPaintings")]
    public async Task<IActionResult> GetAllPaintings(
                                    [FromBody] int? year_from = null,
                                    [FromBody] int? year_to = null,
                                    [FromBody] string? painting_name = null,
                                    [FromBody] string? movement_name = null,
                                    [FromBody] string? genre_name = null)
    {
        var paintingsDto = await galleryRepository
                                .GetAllAsync(year_from, year_to, painting_name, movement_name, genre_name);

        if (paintingsDto.Count == 0)
            return NotFound(new { message = "Paintings not found" });

        return Ok(paintingsDto);
    }
}
