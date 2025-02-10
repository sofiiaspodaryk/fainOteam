using System;
using System.Collections.Generic;

namespace Polotno.API.Models;

public partial class Painting
{
    public int PaintingId { get; set; }

    public string PaintingName { get; set; } = null!;

    public int ArtistId { get; set; }

    public int? StyleId { get; set; }

    public int? GenreId { get; set; }

    public int? YearCreated { get; set; }

    public string? PaintingDescription { get; set; }

    public virtual Artist Artist { get; set; } = null!;

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual Genre? Genre { get; set; }

    public virtual ArtMovement? Style { get; set; }
}
