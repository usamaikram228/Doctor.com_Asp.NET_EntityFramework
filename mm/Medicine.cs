using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Medicine
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Diagnosis { get; set; }

    public int? Price { get; set; }

    public string? Quantity { get; set; }
}
