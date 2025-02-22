using Polotno.API.DTO;
using Polotno.API.Models;

namespace Polotno.API.Repositories
{
    public interface IGalleryRepository
    {
        Task<List<PaintingDto>> GetAllAsync(
                                int? year_from,
                                int? year_to,
                                string? painting_name,
                                string? movement_name,
                                string? genre_name
                                );

        Task<PaintingDto?> GetByIdAsync(int id);
    }
}