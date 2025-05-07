using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class DishItem
{
    public int DishItemId { get; set; }

    public int? DishId { get; set; }

    public int? ItemId { get; set; }

    public int? Qty { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? Isdeleted { get; set; }

    public virtual Dish? Dish { get; set; }

    public virtual Product? Item { get; set; }
}
