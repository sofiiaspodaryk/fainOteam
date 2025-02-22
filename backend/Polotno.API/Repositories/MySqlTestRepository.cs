using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Polotno.API.DTO;
using Polotno.API.Models;

namespace Polotno.API.Repositories
{
    public class MySqlTestRepository : ITestRepository
    {
        private readonly PolotnoContext _dbContext;
        private readonly IMapper _mapper;

        public MySqlTestRepository(PolotnoContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<TestSummaryDto>> GetAllAsync()
        {
            var testSummaries = await _dbContext.Tests
                                .Select(t => _mapper.Map<TestSummaryDto>(t))
                                .ToListAsync();

            return testSummaries;
        }

        public async Task<TestDto?> GetByIdAsync(int id)
        {
            var testDto = await _dbContext.Tests
                            .Include(t => t.Questions)
                                .ThenInclude(q => q.Answers)
                            .FirstOrDefaultAsync(t => t.TestId == id);

            return _mapper.Map<TestDto>(testDto);
        }
    }
}