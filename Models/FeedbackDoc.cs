using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class FeedbackDoc
{
    public int FeedbackDocsId { get; set; }

    public int? FeedbackId { get; set; }

    public string? Path { get; set; }

    public string? Type { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? IsDeleted { get; set; }

    public virtual Feedback? Feedback { get; set; }
}
