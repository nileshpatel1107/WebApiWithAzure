using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class DishItemDatum
{
    public int DishItemId { get; set; }

    public int? DishId { get; set; }

    public int? ItemId { get; set; }

    public int? Qty { get; set; }

    public virtual DishDatum? Dish { get; set; }

    public virtual ProductsDatum? Item { get; set; }
}
