namespace ITProjectCalculator.Data.Entities;

public class ProjectResource
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ResourceType { get; set; } = string.Empty; // Employee, Executor, SubContractor, Equipment
    public int ExecutorId { get; set; }
    public string ServiceName { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal CostPrice { get; set; }
    public decimal Margin { get; set; } // %
    public decimal TotalCost { get; set; } // CostPrice * (1 + Margin/100)
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
