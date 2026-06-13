using ITProjectCalculator.Data.Entities;

namespace ITProjectCalculator.Services.Interfaces;

public interface ICostCalculationService
{
    // Executor cost calculation: su = ((cez * suz) + ((cez * suz) * ns))
    decimal CalculateExecutorCost(decimal quantity, decimal costPerUnit, decimal taxRate);

    // Equipment cost calculation: su = (cez * soz)
    decimal CalculateEquipmentCost(decimal quantity, decimal costPerUnit);

    // Resource total cost: i = s * (1 + m/100)
    decimal CalculateResourceTotalCost(decimal costPrice, decimal margin);

    // Project total cost: sum of all resource costs
    decimal CalculateProjectTotalCost(List<ProjectResource> resources);

    // Project cost with tax: isp = sp + (sp * ns)
    decimal CalculateProjectCostWithTax(decimal totalCost, decimal taxRate);

    // Net profit: p = (i - s) for each service
    decimal CalculateNetProfit(List<ProjectResource> resources);
}
