using System.ComponentModel.DataAnnotations;

public class Role
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } // Admin, Manager, Cashier, Waiter

    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<RolePermission> RolePermissions { get; set; }
}