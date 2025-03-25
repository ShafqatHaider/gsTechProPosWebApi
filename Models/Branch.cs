using System.ComponentModel.DataAnnotations;

public class Branch
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }

    [Required]
    [MaxLength(100)]
    public string BranchName { get; set; }

    [Required]
    [MaxLength(200)]
    public string Location { get; set; }

    public int? ManagerId { get; set; }
    public User Manager { get; set; }
}