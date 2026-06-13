namespace ITProjectCalculator.Data.Entities;

public class Equipment
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PurchaseType { get; set; } = string.Empty; // Own, Rent
    public decimal? OperationalCost { get; set; } // Only for Rent
    public string MeasurementUnit { get; set; } = string.Empty; // hours, days, full cost
    public decimal CostPerUnit { get; set; }
    public List<EquipmentService> Services { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class EquipmentService
{
    public int Id { get; set; }
    public int EquipmentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string MeasurementUnit { get; set; } = string.Empty;
    public decimal CostPerUnit { get; set; }
}
