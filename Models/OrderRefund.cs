using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class OrderRefund
{
    public int OrderRefundId { get; set; }

    public int? OrderId { get; set; }

    public int? OrderItemId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? RefundDate { get; set; }

    public decimal? Percentage { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? IsDeleted { get; set; }

    public virtual Order? Order { get; set; }

    public virtual OrderItem? OrderItem { get; set; }
}
