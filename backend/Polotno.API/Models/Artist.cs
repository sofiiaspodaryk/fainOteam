using System;
using System.Collections.Generic;

namespace Polotno.API.Models;

public partial class Artist
{
    public int ArtistId { get; set; }

    public string? PathToTheImage { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public DateTime? DateOfDeath { get; set; }

    public string? PlaceOfBirth { get; set; }

    public int? MovementId { get; set; }

    public int? GenreId { get; set; }

    public string? Bio { get; set; }

    public virtual Genre? Genre { get; set; }

    public virtual ArtMovement? Movement { get; set; }

    public virtual ICollection<Painting> Paintings { get; set; } = new List<Painting>();

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
