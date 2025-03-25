using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Product
{
    [Key]
    public int Id {get;set;}
    [Required]
    [MaxLength(100)]
    public string Name {get;set;}
    [Required]
    public decimal price {get;set;}
    public int stock {get;set;}
    public string? description {get;set;}
    [Required]
    [ForeignKey("Category ")]
    public int cateId {get;set;}
    [JsonIgnore] 
    public Category Category {get;set;}
    public int branchId {get;set;}
}

