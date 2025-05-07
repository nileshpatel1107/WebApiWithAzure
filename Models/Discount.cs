using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class Discount
{
    public int DiscountId { get; set; }

    public DateTime? From { get; set; }

    public DateTime? To { get; set; }

    public string? Type { get; set; }

    public decimal? Value { get; set; }

    public int? NumberOfTimes { get; set; }

    public decimal? MaxDiscount { get; set; }

    public string? CouponName { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? IsDeleted { get; set; }
}
