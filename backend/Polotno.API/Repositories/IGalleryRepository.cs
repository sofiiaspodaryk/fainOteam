using Polotno.API.DTO;
using Polotno.API.Models;

namespace Polotno.API.Repositories
{
    public interface IGalleryRepository
    {
        Task<List<PaintingDto>> GetAllAsync();
        Task<PaintingDto?> GetByIdAsync(int id);
    } 
}