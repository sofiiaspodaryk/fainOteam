using System;
using System.Collections.Generic;

namespace Polotno.API.Models;

public partial class Test
{
    public int TestId { get; set; }

    public string TestName { get; set; } = null!;

    public int? Difficulty { get; set; }

    public int? ArtistId { get; set; }

    public virtual Artist? Artist { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<UserTestResult> UserTestResults { get; set; } = new List<UserTestResult>();
}
