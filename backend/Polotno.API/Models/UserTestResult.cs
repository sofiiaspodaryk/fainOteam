using System;
using System.Collections.Generic;

namespace Polotno.API.Models;

public partial class UserTestResult
{
    public int ResultId { get; set; }

    public int UserId { get; set; }

    public int TestId { get; set; }

    public int Score { get; set; }

    public DateTime CompletionDate { get; set; }

    public virtual Test Test { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
