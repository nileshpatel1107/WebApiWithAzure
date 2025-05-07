using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class CookingSession
{
    public int SessionId { get; set; }

    public int? TranierId { get; set; }

    public DateTime? SessionDate { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? IsDeleted { get; set; }

    public virtual ICollection<CookingSessionAttendee> CookingSessionAttendees { get; set; } = new List<CookingSessionAttendee>();

    public virtual User? Tranier { get; set; }
}
