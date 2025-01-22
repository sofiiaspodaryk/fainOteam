using Microsoft.AspNetCore.Mvc;
using Polotno.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Polotno.API.Controllers;

[ApiController]
[Route("fainoteam")]
public class GalleryController : ControllerBase
{
    private readonly PolotnoContext _context;

    public GalleryController(PolotnoContext context)
    {
        _context = context;
    }

    // GET: /fainoteam/getPaintingById/{id}
    [HttpGet("getPaintingById/{id}")]
    public async Task<IActionResult> GetPaintingById(int id)
    {
        var painting = await _context.Paintings
            .Where(p => p.PaintingId == id)
            .Select(p => new
            {
                p.PaintingId,
                PaintingName = p.PaintingName,
                ArtistFirstName = p.Artist.FirstName,
                ArtistSecondName = p.Artist.LastName,
                MovementName = p.Artist.Movement.MovementName,
                GenreName = p.Genre.GenreName
            })
            .FirstOrDefaultAsync();

        if (painting == null)
            return NotFound(new { message = "Painting not found" });

        return Ok(painting);
    }

    // GET: /fainoteam/getAllPainting/
    [HttpGet("getAllPainting")]
    public async Task<IActionResult> GetAllPaintings()
    {
        var paintings = await _context.Paintings
            .Select(p => new
            {
                p.PaintingId,
                PaintingName = p.PaintingName,
                ArtistFirstName = p.Artist.FirstName,
                ArtistSecondName = p.Artist.LastName,
                MovementName = p.Artist.Movement.MovementName,
                GenreName = p.Genre.GenreName
            })
            .ToListAsync();

        return Ok(paintings);
    }
}
