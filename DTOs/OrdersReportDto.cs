public class OrdersReportDto
{
    public int BranchId { get; set; }
    public int OrderCount { get; set; }
    public decimal TotalRevenue { get; set; }
    public DateTime ReportDate { get; set; }
}