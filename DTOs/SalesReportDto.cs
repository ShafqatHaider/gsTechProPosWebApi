public class SalesReportDto
{
    public int BranchId { get; set; }
    public decimal TotalSales { get; set; }
    public int TotalOrders { get; set; }
    public DateTime ReportDate { get; set; }
}