using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class CookingSessionAttendee
{
    public int CookingSessionAttendeeId { get; set; }

    public int? SessionId { get; set; }

    public int? AttendeeId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? IsDeleted { get; set; }

    public virtual User? Attendee { get; set; }

    public virtual CookingSession? Session { get; set; }
}
