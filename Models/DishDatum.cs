using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class DishDatum
{
    public int DishId { get; set; }

    public int? ItemId { get; set; }

    public string? Type { get; set; }

    public DateOnly? Date { get; set; }

    public int? DishCount { get; set; }

    public virtual ICollection<DishItemDatum> DishItemData { get; set; } = new List<DishItemDatum>();

    public virtual ProductsDatum? Item { get; set; }
}
