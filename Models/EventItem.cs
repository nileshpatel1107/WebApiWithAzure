using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class EventItem
{
    public int EventItemId { get; set; }

    public int? EventId { get; set; }

    public int? ItemId { get; set; }

    public int? Qty { get; set; }

    public decimal? TotalAmount { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? IsDeleted { get; set; }

    public virtual Event? Event { get; set; }

    public virtual Product? Item { get; set; }
}
