using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? Isdeleted { get; set; }

    public virtual ICollection<CartItemId> CartItemIds { get; set; } = new List<CartItemId>();

    public virtual User? User { get; set; }
}
