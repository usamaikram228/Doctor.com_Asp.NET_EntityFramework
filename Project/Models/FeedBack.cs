using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class FeedBack
{
    public int Id { get; set; }

    public int DoctorId { get; set; }

    public int PatientId { get; set; }

    public int Rating { get; set; }

    public string? Comments { get; set; }

    public DateTime TimeStamp { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
