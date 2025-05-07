using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int? OrderId { get; set; }

    public int? ItemId { get; set; }

    public string? Type { get; set; }

    public int? Quantity { get; set; }

    public decimal? Amount { get; set; }

    public int? TaxPercentage { get; set; }

    public decimal? TaxAmount { get; set; }

    public decimal? Discount { get; set; }

    public int? DiscountId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? Isdeleted { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual Product? Item { get; set; }

    public virtual Order? Order { get; set; }

    public virtual ICollection<OrderRefund> OrderRefunds { get; set; } = new List<OrderRefund>();
}
