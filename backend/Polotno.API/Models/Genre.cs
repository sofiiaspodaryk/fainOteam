using System;
using System.Collections.Generic;

namespace Polotno.API.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;

    public string GenreDescription { get; set; } = null!;

    public virtual ICollection<Artist> Artists { get; set; } = new List<Artist>();

    public virtual ICollection<Painting> Paintings { get; set; } = new List<Painting>();
}
