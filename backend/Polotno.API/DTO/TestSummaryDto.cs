namespace Polotno.API.DTO
{
    public class TestSummaryDto
    {
        public int TestId { get; set; }

        public string TestName { get; set; } = null!;

        public int Difficulty { get; set; }
    }
}