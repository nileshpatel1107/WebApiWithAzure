using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class Overtime
{
    public int OvertimeId { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? IsDeleted { get; set; }

    public virtual User? User { get; set; }
}
