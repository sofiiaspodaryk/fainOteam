using System;
using System.Collections.Generic;

namespace Polotno.API.Models;

public partial class Favorite
{
    public int UserId { get; set; }

    public int PaintingId { get; set; }

    public DateTime AddedAt { get; set; }

    public virtual Painting Painting { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
