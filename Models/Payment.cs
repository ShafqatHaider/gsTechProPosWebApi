using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Payment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int OrderId { get; set; }
    public Order Order { get; set; }

    [Required]
    public string PaymentType { get; set; } // Cash, Card

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal AmountPaid { get; set; }

    [Required]
    public string Status { get; set; } // Paid, Unpaid

    public string TransactionId { get; set; }
}