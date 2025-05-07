using System;
using System.Collections.Generic;

namespace NileshWebApi.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Email { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? ContactNo { get; set; }

    public string? Fullname { get; set; }

    public string? Password { get; set; }

    public string? Type { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CratedBy { get; set; }

    public int? Isdeleted { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<CookingSessionAttendee> CookingSessionAttendees { get; set; } = new List<CookingSessionAttendee>();

    public virtual ICollection<CookingSession> CookingSessions { get; set; } = new List<CookingSession>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Leave> Leaves { get; set; } = new List<Leave>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Overtime> Overtimes { get; set; } = new List<Overtime>();

    public virtual ICollection<ReservedTable> ReservedTables { get; set; } = new List<ReservedTable>();

    public virtual ICollection<RolesUser> RolesUsers { get; set; } = new List<RolesUser>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
