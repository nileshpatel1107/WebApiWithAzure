using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public decimal? Threshold { get; set; }

    public string? WeightType { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public decimal? Price { get; set; }

    public bool? Visible { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? Isdeleted { get; set; }

    public virtual ICollection<CartItemId> CartItemIds { get; set; } = new List<CartItemId>();

    public virtual ICollection<DishItem> DishItems { get; set; } = new List<DishItem>();

    public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();

    public virtual ICollection<EventItem> EventItems { get; set; } = new List<EventItem>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public virtual ICollection<VendorProduct> VendorProducts { get; set; } = new List<VendorProduct>();
}
