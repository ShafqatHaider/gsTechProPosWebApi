using System.ComponentModel.DataAnnotations;

public class Permission
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } // View Orders, Manage Payments

    public ICollection<RolePermission> RolePermissions { get; set; }
}