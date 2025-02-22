namespace Polotno.API.DTO
{
    public class AnswerDto
    {
        public int AnswerId { get; set; }

        public string AnswerText { get; set; } = null!;

        public bool IsCorrect { get; set; }
    }
}