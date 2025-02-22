using Microsoft.AspNetCore.Mvc;
using Polotno.API.Repositories;

namespace Polotno.API.Controllers
{
    [ApiController]
    [Route("fainoteam")]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepository;

        public TestController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        // GET: /fainoteam/tests/
        [HttpGet("tests")]
        public async Task<IActionResult> GetAllTests()
        {
            var testSummariesDto = await _testRepository.GetAllAsync();

            return Ok(testSummariesDto);
        }

        // GET: /fainoteam/tests/{id}
        [HttpGet("tests/{id}")]
        public async Task<IActionResult> GetTestById([FromRoute] int id)
        {
            var testDto = await _testRepository.GetByIdAsync(id);

            if (testDto == null)
                return NotFound(new { message = "Test not found" });

            return Ok(testDto);
        }
    }

}