using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class MyCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DisplayOrder { get; set; }
}
