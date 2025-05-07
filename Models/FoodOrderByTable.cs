using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class FoodOrderByTable
{
    public int OrderId { get; set; }

    public int? FoodId { get; set; }

    public int? ItemQuantity { get; set; }

    public int? ReservedTableId { get; set; }

    public string Status { get; set; } = null!;

    public virtual FoodItem? Food { get; set; }

    public virtual ReservedTable? ReservedTable { get; set; }
}
