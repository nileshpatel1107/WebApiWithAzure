using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class UsersDatum
{
    public int UserId { get; set; }

    public DateOnly? Birthdate { get; set; }

    public string? ContactNo { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Type { get; set; }

    public int? Typeid { get; set; }

    public virtual UserType? TypeNavigation { get; set; }
}
