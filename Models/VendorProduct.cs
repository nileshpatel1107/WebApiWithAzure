using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class VendorProduct
{
    public int VendorProductId { get; set; }

    public int? VendorId { get; set; }

    public string? ProductName { get; set; }

    public decimal? Price { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? IsDeleted { get; set; }

    public int? ItemId { get; set; }

    public virtual Product? Item { get; set; }

    public virtual Vendor? Vendor { get; set; }
}
