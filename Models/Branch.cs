using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Branch
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int RestaurantId { get; set; }
    [JsonIgnore] 
    public Restaurant Restaurant { get; set; }

    [Required]
    [MaxLength(100)]
    public string BranchName { get; set; }

    [Required]
    [MaxLength(200)]
    public string Location { get; set; }

    public int? ManagerId { get; set; }
    [JsonIgnore] 
    public User Manager { get; set; }
}