using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class ReservedTable
{
    public int ReservedTableId { get; set; }

    public int? TableId { get; set; }

    public int? UserId { get; set; }

    public int? NoOfpeople { get; set; }

    public DateTime? FromDateTime { get; set; }

    public DateTime? ToDateTime { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? IsDeleted { get; set; }

    public virtual ICollection<FoodOrderByTable> FoodOrderByTables { get; set; } = new List<FoodOrderByTable>();

    public virtual DineInTable? Table { get; set; }

    public virtual User? User { get; set; }
}
