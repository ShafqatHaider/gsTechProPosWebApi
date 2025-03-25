using Microsoft.EntityFrameworkCore;

public class AppDbContext :DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public DbSet<User> Users {get;set;}
    public DbSet<Restaurant> Restaurants {get;set;}
    public DbSet<Order> Orders {get;set;}
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Branch> Branch { get; set; }
    public DbSet<OrderItem> OrderItem { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
}