using System;
using System.Collections.Generic;

namespace Polotno.API.Models;

public partial class ArtMovement
{
    public int MovementId { get; set; }

    public string MovementName { get; set; } = null!;

    public string MovementDescription { get; set; } = null!;

    public virtual ICollection<Artist> Artists { get; set; } = new List<Artist>();

    public virtual ICollection<Painting> Paintings { get; set; } = new List<Painting>();
}
