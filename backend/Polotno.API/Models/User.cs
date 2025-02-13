using System;
using System.Collections.Generic;

namespace Polotno.API.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? PathToTheImage { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<UserTestResult> UserTestResults { get; set; } = new List<UserTestResult>();
}
