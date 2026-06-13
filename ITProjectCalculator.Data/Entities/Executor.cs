namespace ITProjectCalculator.Data.Entities;

public class Executor
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Patronymic { get; set; } = string.Empty;
    public string RegistrationType { get; set; } = string.Empty; // ГПХ, НПД
    public decimal TaxRate { get; set; } // 0 for НПД, custom for ГПХ
    public string MeasurementUnit { get; set; } = string.Empty; // hours, days, full cost
    public decimal CostPerUnit { get; set; }
    public List<ExecutorService> Services { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class ExecutorService
{
    public int Id { get; set; }
    public int ExecutorId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string MeasurementUnit { get; set; } = string.Empty;
    public decimal CostPerUnit { get; set; }
}
