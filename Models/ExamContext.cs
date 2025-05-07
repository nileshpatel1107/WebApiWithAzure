using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NileshWebApi.Models;

public partial class ExamContext : DbContext
{
    public ExamContext()
    {
    }

    public ExamContext(DbContextOptions<ExamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItemId> CartItemIds { get; set; }

    public virtual DbSet<CookingSession> CookingSessions { get; set; }

    public virtual DbSet<CookingSessionAttendee> CookingSessionAttendees { get; set; }

    public virtual DbSet<CookingSessoinAttendeeReport> CookingSessoinAttendeeReports { get; set; }

    public virtual DbSet<DineInTable> DineInTables { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Dish> Dishes { get; set; }

    public virtual DbSet<DishDatum> DishData { get; set; }

    public virtual DbSet<DishItem> DishItems { get; set; }

    public virtual DbSet<DishItemDatum> DishItemData { get; set; }

    public virtual DbSet<Dishtype> Dishtypes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventItem> EventItems { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<FeedbackDoc> FeedbackDocs { get; set; }

    public virtual DbSet<FoodItem> FoodItems { get; set; }

    public virtual DbSet<FoodOrderByTable> FoodOrderByTables { get; set; }

    public virtual DbSet<Holiday> Holidays { get; set; }

    public virtual DbSet<Leave> Leaves { get; set; }

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<MyCategory> MyCategories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderRefund> OrderRefunds { get; set; }

    public virtual DbSet<Overtime> Overtimes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductMenu> ProductMenus { get; set; }

    public virtual DbSet<ProductMenuItem> ProductMenuItems { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<ProductsDatum> ProductsData { get; set; }

    public virtual DbSet<ReservedTable> ReservedTables { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolesProductMenu> RolesProductMenus { get; set; }

    public virtual DbSet<RolesUser> RolesUsers { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    public virtual DbSet<UsersDatum> UsersData { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    public virtual DbSet<VendorProduct> VendorProducts { get; set; }

    public virtual DbSet<WhatsAppMessage> WhatsAppMessages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.1.145,1435;Database=Exam;User Id=yash;Password=Sit@321#;TrustServerCertificate=True;MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetRoles");

            entity.HasIndex(e => e.Name, "RoleNameIndex").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUsers");

            entity.ToTable(tb => tb.HasTrigger("trg_AfterInsertUser"));

            entity.HasIndex(e => e.UserName, "UserNameIndex").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.BirthDate)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime");
            entity.Property(e => e.ContactNo)
                .HasMaxLength(10)
                .HasDefaultValue("");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK_dbo.AspNetUserRoles");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_RoleId");
                        j.HasIndex(new[] { "UserId" }, "IX_UserId");
                        j.IndexerProperty<string>("UserId").HasMaxLength(128);
                        j.IndexerProperty<string>("RoleId").HasMaxLength(128);
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUserClaims");

            entity.HasIndex(e => e.UserId, "IX_UserId");

            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId }).HasName("PK_dbo.AspNetUserLogins");

            entity.HasIndex(e => e.UserId, "IX_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);
            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__51BCD7B7307899E4");

            entity.ToTable("Cart");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Cart__UserId__36B12243");
        });

        modelBuilder.Entity<CartItemId>(entity =>
        {
            entity.HasKey(e => e.CartItemId1).HasName("PK__CartItem__488B0B0ADB55CCFF");

            entity.ToTable("CartItemId");

            entity.Property(e => e.CartItemId1).HasColumnName("CartItemId");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartItemIds)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK__CartItemI__CartI__398D8EEE");

            entity.HasOne(d => d.Item).WithMany(p => p.CartItemIds)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__CartItemI__ItemI__3A81B327");
        });

        modelBuilder.Entity<CookingSession>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__CookingS__C9F49290CCCB4A7F");

            entity.ToTable("CookingSession");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.SessionDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Tranier).WithMany(p => p.CookingSessions)
                .HasForeignKey(d => d.TranierId)
                .HasConstraintName("FK__CookingSe__Trani__628FA481");
        });

        modelBuilder.Entity<CookingSessionAttendee>(entity =>
        {
            entity.HasKey(e => e.CookingSessionAttendeeId).HasName("PK__CookingS__B4CEC63B5F389DAF");

            entity.ToTable("CookingSessionAttendee");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Attendee).WithMany(p => p.CookingSessionAttendees)
                .HasForeignKey(d => d.AttendeeId)
                .HasConstraintName("FK__CookingSe__Atten__66603565");

            entity.HasOne(d => d.Session).WithMany(p => p.CookingSessionAttendees)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK__CookingSe__Sessi__656C112C");
        });

        modelBuilder.Entity<CookingSessoinAttendeeReport>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CookingSessoinAttendeeReport");

            entity.Property(e => e.SessionDate)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Trainer)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DineInTable>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK__DineInTa__7D5F01EEDBC47714");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.NoOfchairs).HasColumnName("NoOFChairs");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.DiscountId).HasName("PK__Discount__E43F6D9628D8E1AE");

            entity.ToTable("Discount");

            entity.Property(e => e.CouponName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.From).HasColumnType("datetime");
            entity.Property(e => e.MaxDiscount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.To).HasColumnType("datetime");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Value).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Dish>(entity =>
        {
            entity.HasKey(e => e.DishId).HasName("PK__Dish__18834F506E98DF0A");

            entity.ToTable("Dish");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Item).WithMany(p => p.Dishes)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__Dish__ItemID__300424B4");
        });

        modelBuilder.Entity<DishDatum>(entity =>
        {
            entity.HasKey(e => e.DishId).HasName("PK__DishData__18834F50D5E75A1E");

            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Item).WithMany(p => p.DishData)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__DishData__ItemId__18EBB532");
        });

        modelBuilder.Entity<DishItem>(entity =>
        {
            entity.HasKey(e => e.DishItemId).HasName("PK__DishItem__F0C0B87CF5C9D245");

            entity.ToTable("DishItem");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Dish).WithMany(p => p.DishItems)
                .HasForeignKey(d => d.DishId)
                .HasConstraintName("FK__DishItem__DishId__32E0915F");

            entity.HasOne(d => d.Item).WithMany(p => p.DishItems)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__DishItem__ItemID__33D4B598");
        });

        modelBuilder.Entity<DishItemDatum>(entity =>
        {
            entity.HasKey(e => e.DishItemId).HasName("PK__DishItem__F0C0B87CC86DA0BE");

            entity.HasOne(d => d.Dish).WithMany(p => p.DishItemData)
                .HasForeignKey(d => d.DishId)
                .HasConstraintName("FK__DishItemD__DishI__1BC821DD");

            entity.HasOne(d => d.Item).WithMany(p => p.DishItemData)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__DishItemD__ItemI__1CBC4616");
        });

        modelBuilder.Entity<Dishtype>(entity =>
        {
            entity.HasKey(e => e.Dishid).HasName("PK__dishtype__76DEBE3B60BE8D8C");

            entity.ToTable("dishtype");

            entity.Property(e => e.Dishid).HasColumnName("dishid");
            entity.Property(e => e.Dishtype1)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("dishtype");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07A13E296F");

            entity.Property(e => e.Department)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Designation)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Event__7944C8102D0A6DA7");

            entity.ToTable("Event");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Duration)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EventDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Events)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Event__UserId__2739D489");
        });

        modelBuilder.Entity<EventItem>(entity =>
        {
            entity.HasKey(e => e.EventItemId).HasName("PK__EventIte__0369CECFE9E65AE2");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Event).WithMany(p => p.EventItems)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__EventItem__Event__59063A47");

            entity.HasOne(d => d.Item).WithMany(p => p.EventItems)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__EventItem__ItemI__59FA5E80");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDD6FDB76874");

            entity.ToTable("Feedback");

            entity.Property(e => e.Comments).IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Order).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Feedback__OrderI__412EB0B6");

            entity.HasOne(d => d.OrderItem).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.OrderItemId)
                .HasConstraintName("FK__Feedback__OrderI__4222D4EF");
        });

        modelBuilder.Entity<FeedbackDoc>(entity =>
        {
            entity.HasKey(e => e.FeedbackDocsId).HasName("PK__Feedback__9DBFC3AAA17C81AA");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Path)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Feedback).WithMany(p => p.FeedbackDocs)
                .HasForeignKey(d => d.FeedbackId)
                .HasConstraintName("FK__FeedbackD__Feedb__44FF419A");
        });

        modelBuilder.Entity<FoodItem>(entity =>
        {
            entity.HasKey(e => e.FoodId).HasName("PK__FoodItem__77EAEA395B9BC284");

            entity.Property(e => e.FoodId).HasColumnName("foodId");
            entity.Property(e => e.ItemName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("itemName");
            entity.Property(e => e.ItemPrice).HasColumnName("itemPrice");
        });

        modelBuilder.Entity<FoodOrderByTable>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__FoodOrde__0809335DACC87FFF");

            entity.ToTable("FoodOrderByTable");

            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.FoodId).HasColumnName("foodId");
            entity.Property(e => e.ItemQuantity).HasColumnName("itemQuantity");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.HasOne(d => d.Food).WithMany(p => p.FoodOrderByTables)
                .HasForeignKey(d => d.FoodId)
                .HasConstraintName("FK__FoodOrder__foodI__719CDDE7");

            entity.HasOne(d => d.ReservedTable).WithMany(p => p.FoodOrderByTables)
                .HasForeignKey(d => d.ReservedTableId)
                .HasConstraintName("FK__FoodOrder__Reser__72910220");
        });

        modelBuilder.Entity<Holiday>(entity =>
        {
            entity.HasKey(e => e.HolidayId).HasName("PK__Holiday__EB855CEFE7675EC2");

            entity.ToTable("Holiday");

            entity.Property(e => e.HolidayId).HasColumnName("holidayId");
            entity.Property(e => e.HolidayMonthDay)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("holidayMonthDay");
            entity.Property(e => e.HolidayName)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("holidayName");
        });

        modelBuilder.Entity<Leave>(entity =>
        {
            entity.HasKey(e => e.LeaveId).HasName("PK__Leave__796DB959A0962DE0");

            entity.ToTable("Leave");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EndDuration)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.Reason).IsUnicode(false);
            entity.Property(e => e.ResponseComment).IsUnicode(false);
            entity.Property(e => e.StartDuration)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ToDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Leaves)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Leave__UserId__4AB81AF0");
        });

        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<MyCategory>(entity =>
        {
            entity.ToTable("myCategories");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCF5A31C591");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DateOfOrder).HasColumnType("datetime");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__29572725");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED06811B2CEABB");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Discount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Item).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__OrderItem__ItemI__2D27B809");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderItem__Order__2C3393D0");
        });

        modelBuilder.Entity<OrderRefund>(entity =>
        {
            entity.HasKey(e => e.OrderRefundId).HasName("PK__OrderRef__9273F2617E9E0615");

            entity.ToTable("OrderRefund");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Percentage).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RefundDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderRefunds)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderRefu__Order__3D5E1FD2");

            entity.HasOne(d => d.OrderItem).WithMany(p => p.OrderRefunds)
                .HasForeignKey(d => d.OrderItemId)
                .HasConstraintName("FK__OrderRefu__Order__3E52440B");
        });

        modelBuilder.Entity<Overtime>(entity =>
        {
            entity.HasKey(e => e.OvertimeId).HasName("PK__Overtime__F61430B8D2DBF3BF");

            entity.ToTable("Overtime");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.ToDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Overtimes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Overtime__UserId__4D94879B");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CD3D85D67B");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Threshold).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.WeightType)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProductMenu>(entity =>
        {
            entity.HasKey(e => e.ProductMenuId).HasName("pk_prodMenuId");

            entity.ToTable("ProductMenu");

            entity.Property(e => e.ProductMenuId).HasColumnName("productMenuId");
            entity.Property(e => e.MenuItem1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("menuItem1");
            entity.Property(e => e.MenuName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("menuName");
            entity.Property(e => e.RoleId).HasColumnName("roleId");

            entity.HasOne(d => d.Role).WithMany(p => p.ProductMenus)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__ProductMe__roleI__7F2BE32F");
        });

        modelBuilder.Entity<ProductMenuItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductM__3213E83FC24E50EE");

            entity.ToTable("ProductMenuItem");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Itemdesc)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("itemdesc");
            entity.Property(e => e.Itemname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("itemname");

            entity.HasOne(d => d.ProductMenu).WithMany(p => p.ProductMenuItems)
                .HasForeignKey(d => d.ProductMenuId)
                .HasConstraintName("FK__ProductMe__Produ__3493CFA7");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__productT__DD37D91A38695159");

            entity.ToTable("productType");

            entity.Property(e => e.Pid).HasColumnName("pid");
            entity.Property(e => e.Ptype)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ptype");
        });

        modelBuilder.Entity<ProductsDatum>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CDE23ECE89");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Thresold).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Visible).HasColumnName("visible");
            entity.Property(e => e.WeightType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ReservedTable>(entity =>
        {
            entity.HasKey(e => e.ReservedTableId).HasName("PK__Reserved__3E53FB19E8E4D45A");

            entity.ToTable("ReservedTable");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.FromDateTime).HasColumnType("datetime");
            entity.Property(e => e.NoOfpeople).HasColumnName("NoOFPeople");
            entity.Property(e => e.ToDateTime).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Table).WithMany(p => p.ReservedTables)
                .HasForeignKey(d => d.TableId)
                .HasConstraintName("FK__ReservedT__Table__5EBF139D");

            entity.HasOne(d => d.User).WithMany(p => p.ReservedTables)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ReservedT__UserI__5FB337D6");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("pk_roleId");

            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("roleName");
        });

        modelBuilder.Entity<RolesProductMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RolesPro__3213E83FB9C20FD2");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProductMenuId).HasColumnName("productMenuId");
            entity.Property(e => e.RoleId).HasColumnName("roleId");

            entity.HasOne(d => d.ProductMenu).WithMany(p => p.RolesProductMenus)
                .HasForeignKey(d => d.ProductMenuId)
                .HasConstraintName("FK__RolesProd__produ__45BE5BA9");

            entity.HasOne(d => d.Role).WithMany(p => p.RolesProductMenus)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__RolesProd__roleI__44CA3770");
        });

        modelBuilder.Entity<RolesUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Role).WithMany(p => p.RolesUsers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__RolesUser__roleI__71D1E811");

            entity.HasOne(d => d.User).WithMany(p => p.RolesUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__RolesUser__userI__72C60C4A");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PK__Stocks__2C83A9C2951272D1");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Stocks_Users");

            entity.HasOne(d => d.Item).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__Stocks__ItemId__47DBAE45");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("FK__Stocks__VendorId__6CD828CA");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CA77ABD05");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105348210C26B").IsUnique();

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.ContactNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fullname)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK__UserType__DD701264844504C2");

            entity.ToTable("UserType");

            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.Uname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("uname");
        });

        modelBuilder.Entity<UsersDatum>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UsersDat__1788CC4C6485F45F");

            entity.Property(e => e.ContactNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Typeid).HasColumnName("typeid");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.UsersData)
                .HasForeignKey(d => d.Typeid)
                .HasConstraintName("FK__UsersData__typei__2180FB33");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PK__Vendor__FC8618F36961E784");

            entity.ToTable("Vendor");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.VendorAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.VendorEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.VendorName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VendorProduct>(entity =>
        {
            entity.HasKey(e => e.VendorProductId).HasName("PK__VendorPr__ABB41163BB377C82");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Item).WithMany(p => p.VendorProducts)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__VendorPro__ItemI__6AEFE058");

            entity.HasOne(d => d.Vendor).WithMany(p => p.VendorProducts)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("FK__VendorPro__Vendo__5441852A");
        });

        modelBuilder.Entity<WhatsAppMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WhatsApp__3214EC2789F80C67");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GroupId)
                .HasMaxLength(255)
                .HasColumnName("group_id");
            entity.Property(e => e.MessageBody).HasColumnName("message_body");
            entity.Property(e => e.MessageId)
                .HasMaxLength(255)
                .HasColumnName("message_id");
            entity.Property(e => e.MessageType)
                .HasMaxLength(50)
                .HasColumnName("message_type");
            entity.Property(e => e.ParticipantId)
                .HasMaxLength(255)
                .HasColumnName("participant_id");
            entity.Property(e => e.Timestamp).HasColumnName("timestamp");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("user_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
