using System.ComponentModel.DataAnnotations;

public class RolePermission
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int RoleId { get; set; }
    public Role Role { get; set; }

    [Required]
    public int PermissionId { get; set; }
    public Permission Permission { get; set; }
}