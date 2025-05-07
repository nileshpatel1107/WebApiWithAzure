using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int? OrderId { get; set; }

    public int? OrderItemId { get; set; }

    public int? Rating { get; set; }

    public DateTime? Date { get; set; }

    public string? Comments { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? IsDeleted { get; set; }

    public virtual ICollection<FeedbackDoc> FeedbackDocs { get; set; } = new List<FeedbackDoc>();

    public virtual Order? Order { get; set; }

    public virtual OrderItem? OrderItem { get; set; }
}
