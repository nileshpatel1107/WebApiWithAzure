using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class ProductMenu
{
    public int ProductMenuId { get; set; }

    public string MenuName { get; set; } = null!;

    public string MenuItem1 { get; set; } = null!;

    public int? RoleId { get; set; }

    public virtual ICollection<ProductMenuItem> ProductMenuItems { get; set; } = new List<ProductMenuItem>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<RolesProductMenu> RolesProductMenus { get; set; } = new List<RolesProductMenu>();
}
