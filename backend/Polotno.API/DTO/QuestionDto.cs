namespace Polotno.API.DTO
{
    public class QuestionDto
    {
        public int QuestionId { get; set; }

        public string QuestionText { get; set; } = null!;

        public List<AnswerDto> Answers { get; set; } = [];
    }
}