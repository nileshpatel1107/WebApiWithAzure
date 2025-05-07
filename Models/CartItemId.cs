using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class CartItemId
{
    public int CartItemId1 { get; set; }

    public int? CartId { get; set; }

    public int? ItemId { get; set; }

    public decimal? Amount { get; set; }

    public int? Qty { get; set; }

    public decimal? TotalAmount { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? Isdeleted { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual Product? Item { get; set; }
}
