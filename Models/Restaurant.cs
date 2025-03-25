using System.ComponentModel.DataAnnotations;

public class Restaurant{
   
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public int OwnerId { get; set; }
    public User Owner { get; set; }

    public ICollection<Branch> Branches { get; set; }    public string logoImgPath {get;set;}
}