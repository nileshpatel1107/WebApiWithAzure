using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class Leave
{
    public int LeaveId { get; set; }

    public int? UserId { get; set; }

    public string? Status { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public string? StartDuration { get; set; }

    public string? EndDuration { get; set; }

    public string? Reason { get; set; }

    public string? ResponseComment { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? IsDeleted { get; set; }

    public virtual User? User { get; set; }
}
