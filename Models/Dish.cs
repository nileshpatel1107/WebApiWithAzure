using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class Dish
{
    public int DishId { get; set; }

    public int? ItemId { get; set; }

    public string? Type { get; set; }

    public DateOnly? Date { get; set; }

    public int? DishCount { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? Isdeleted { get; set; }

    public virtual ICollection<DishItem> DishItems { get; set; } = new List<DishItem>();

    public virtual Product? Item { get; set; }
}
