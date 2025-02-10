namespace Polotno.API.DTO
{
    public class UpdateRequestUserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}