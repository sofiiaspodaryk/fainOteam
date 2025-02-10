using Polotno.API.Models;

namespace Polotno.API.DTO
{
    public class PaintingDto
    {
        public int PaintingId { get; set; }
        public string PaintingName { get; set; } = null!;
        public string ArtistFirstName { get; set; } = null!;
        public string ArtistLastName { get; set; } = null!;
        public string MovementName { get; set; } = null!;
        public string GenreName { get; set; } = null!;
    }
}