using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Patient
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Gender { get; set; }

    public string? Password { get; set; }
}
