using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class Vendor
{
    public int VendorId { get; set; }

    public string? VendorName { get; set; }

    public string? VendorEmail { get; set; }

    public string? VendorAddress { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? IsDeleted { get; set; }

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public virtual ICollection<VendorProduct> VendorProducts { get; set; } = new List<VendorProduct>();
}
