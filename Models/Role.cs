using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<ProductMenu> ProductMenus { get; set; } = new List<ProductMenu>();

    public virtual ICollection<RolesProductMenu> RolesProductMenus { get; set; } = new List<RolesProductMenu>();

    public virtual ICollection<RolesUser> RolesUsers { get; set; } = new List<RolesUser>();
}
