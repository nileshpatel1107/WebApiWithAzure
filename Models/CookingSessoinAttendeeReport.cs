using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class CookingSessoinAttendeeReport
{
    public string? SessionDate { get; set; }

    public int? NoOfAttendees { get; set; }

    public string? Trainer { get; set; }
}
