using Microsoft.EntityFrameworkCore;
using Polotno.API.DTO;
using Polotno.API.Models;

namespace Polotno.API.Repositories
{
    public class MySqlGalleryRepository : IGalleryRepository
    {
        private readonly PolotnoContext dbContext;

        public MySqlGalleryRepository(PolotnoContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<PaintingDto>> GetAllAsync()
        {
            var paintings = await dbContext.Paintings
                            .Include(p => p.Artist)
                            .Include(p => p.Genre)
                            .Include(p => p.Style)
                            .Select(p => new PaintingDto
                            {
                                PaintingId = p.PaintingId,
                                PaintingName = p.PaintingName,
                                ArtistFirstName = p.Artist.FirstName,
                                ArtistLastName = p.Artist.LastName,
                                MovementName = p.Artist.Movement.MovementName,
                                GenreName = p.Genre.GenreName
                            })
                            .ToListAsync();
            return paintings;
        }

        public async Task<PaintingDto?> GetByIdAsync(int id)
        {
            var paintingDto = await dbContext.Paintings
                            .Include(p => p.Artist)
                            .Include(p => p.Genre)
                            .Include(p => p.Style)
                            .Select(p => new PaintingDto
                            {
                                PaintingId = p.PaintingId,
                                PaintingName = p.PaintingName,
                                ArtistFirstName = p.Artist.FirstName,
                                ArtistLastName = p.Artist.LastName,
                                MovementName = p.Artist.Movement.MovementName,
                                GenreName = p.Genre.GenreName
                            })
                            .FirstOrDefaultAsync(x => x.PaintingId == id);
            return paintingDto;
        }
    }
}