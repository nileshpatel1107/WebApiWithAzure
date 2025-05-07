using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class ProductsDatum
{
    public int ProductId { get; set; }

    public decimal? Thresold { get; set; }

    public string? WeightType { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public decimal? Price { get; set; }

    public bool? Visible { get; set; }

    public virtual ICollection<DishDatum> DishData { get; set; } = new List<DishDatum>();

    public virtual ICollection<DishItemDatum> DishItemData { get; set; } = new List<DishItemDatum>();
}
