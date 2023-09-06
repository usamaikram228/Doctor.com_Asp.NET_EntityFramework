using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Doctor
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? City { get; set; }

    public string? Gender { get; set; }

    public string? Specilization { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<FeedBack> FeedBacks { get; set; } = new List<FeedBack>();
}
