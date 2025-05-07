using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class FoodItem
{
    public int FoodId { get; set; }

    public string? ItemName { get; set; }

    public double? ItemPrice { get; set; }

    public virtual ICollection<FoodOrderByTable> FoodOrderByTables { get; set; } = new List<FoodOrderByTable>();
}
