using Polotno.API.DTO;

namespace Polotno.API.Repositories
{
    public interface ITestRepository
    {
        Task<List<TestSummaryDto>> GetAllAsync();

        Task<TestDto?> GetByIdAsync(int id);
    }
}