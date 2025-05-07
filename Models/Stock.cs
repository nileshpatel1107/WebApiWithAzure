using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class Stock
{
    public int StockId { get; set; }

    public int? ItemId { get; set; }

    public int? Qty { get; set; }

    public string? Type { get; set; }

    public int? VendorId { get; set; }

    public DateOnly? Date { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? IsDeleted { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual Product? Item { get; set; }

    public virtual Vendor? Vendor { get; set; }
}
