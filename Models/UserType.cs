using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class UserType
{
    public int Uid { get; set; }

    public string? Uname { get; set; }

    public virtual ICollection<UsersDatum> UsersData { get; set; } = new List<UsersDatum>();
}
