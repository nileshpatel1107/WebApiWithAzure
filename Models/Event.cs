using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class Event
{
    public int EventId { get; set; }

    public DateTime? EventDate { get; set; }

    public string? Duration { get; set; }

    public int? QtyOfDishes { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? IsDeleted { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<EventItem> EventItems { get; set; } = new List<EventItem>();

    public virtual User? User { get; set; }
}
