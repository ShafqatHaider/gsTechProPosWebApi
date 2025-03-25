using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Category{
    [Key]
    public int Id {get;set;}
    [Required]
    [MaxLength(50)]
    public string cateName {get;set;}
    [JsonIgnore] 
    public ICollection<Product> Products {get;set;} = new List<Product>();
}