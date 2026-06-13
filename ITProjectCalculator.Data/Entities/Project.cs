namespace ITProjectCalculator.Data.Entities;

public class Project
{
    public int Id { get; set; }
    public int WorkspaceId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int? CustomerId { get; set; }
    public string Status { get; set; } = "Draft"; // Draft, InProgress, Completed
    public decimal TaxRate { get; set; }
    public List<ProjectResource> Resources { get; set; } = new();
    public string? TechnicalSpecification { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Calculated properties
    public decimal TotalCost { get; set; }
    public decimal CostWithTax { get; set; }
    public decimal NetProfit { get; set; }
}
