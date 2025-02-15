using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        public async Task<List<PaintingDto>> GetAllAsync(
                                            int? year_from,
                                            int? year_to,
                                            string? painting_name,
                                            string? movement_name,
                                            string? genre_name)
        {
            var unfilteredPaintings = dbContext.Paintings
                                    .Include(p => p.Artist)
                                    .Include(p => p.Genre)
                                    .Include(p => p.Style)
                                    .AsQueryable();

            if (year_from.HasValue) unfilteredPaintings = unfilteredPaintings
                                                        .Where(p => p.YearCreated >= year_from);

            if (year_to.HasValue) unfilteredPaintings = unfilteredPaintings
                                                    .Where(p => p.YearCreated <= year_to);

            if (!painting_name.IsNullOrEmpty()) unfilteredPaintings = unfilteredPaintings
                                                                    .Where(p => p.PaintingName.Contains(painting_name!));

            if (!movement_name.IsNullOrEmpty()) unfilteredPaintings = unfilteredPaintings
                                                                    .Where(p => p.Artist.Movement!.MovementName
                                                                    .Contains(movement_name!));

            if (!genre_name.IsNullOrEmpty()) unfilteredPaintings = unfilteredPaintings
                                                                .Where(p => p.Genre!.GenreName.Contains(genre_name!));

            var filteredPaintings = await unfilteredPaintings
                                    .Select(p => new PaintingDto
                                    {
                                        PaintingId = p.PaintingId,
                                        PaintingName = p.PaintingName,
                                        ArtistFirstName = p.Artist.FirstName,
                                        ArtistLastName = p.Artist.LastName,
                                        MovementName = p.Artist.Movement!.MovementName,
                                        GenreName = p.Genre!.GenreName
                                    })
                                    .ToListAsync();

            return filteredPaintings;
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
                                MovementName = p.Artist.Movement!.MovementName,
                                GenreName = p.Genre!.GenreName
                            })
                            .FirstOrDefaultAsync(x => x.PaintingId == id);
            return paintingDto;
        }
    }
}