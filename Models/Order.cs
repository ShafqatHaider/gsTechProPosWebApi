using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Order{
   [Key]
    public int Id { get; set; }

    [Required]
    public int BranchId { get; set; }
    public Branch Branch { get; set; }

    [Required]
    public int TableNumber { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }

    [Required]
    public string OrderStatus { get; set; } // Pending, Completed, Canceled

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<OrderItem> OrderItems { get; set; }
    public Payment Payment { get; set; }
}