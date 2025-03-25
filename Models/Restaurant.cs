using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Restaurant{
   
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public int OwnerId { get; set; }
    public string logoImgPath {get;set;}
    
    public string address {get;set;}
    public string contactNo {get;set;}
    [JsonIgnore] 
    public ICollection<Branch> Branches { get; set; }  = new List<Branch>();   
    [JsonIgnore] 
    public User? Owner { get; set; }
}