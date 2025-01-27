namespace Polotno.API.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}