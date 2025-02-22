namespace Polotno.API.DTO
{
    public class TestDto
    {
        public int TestId { get; set; }

        public string TestName { get; set; } = null!;

        public int Difficulty { get; set; }

        public List<QuestionDto> Questions { get; set; } = [];
    }
}