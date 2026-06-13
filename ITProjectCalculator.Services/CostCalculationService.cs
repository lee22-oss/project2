using ITProjectCalculator.Data.Entities;
using ITProjectCalculator.Services.Interfaces;

namespace ITProjectCalculator.Services;

public class CostCalculationService : ICostCalculationService
{
    public decimal CalculateExecutorCost(decimal quantity, decimal costPerUnit, decimal taxRate)
    {
        // su = ((cez * suz) + ((cez * suz) * ns))
        var baseCost = quantity * costPerUnit;
        var taxAmount = baseCost * (taxRate / 100);
        return baseCost + taxAmount;
    }

    public decimal CalculateEquipmentCost(decimal quantity, decimal costPerUnit)
    {
        // su = (cez * soz)
        return quantity * costPerUnit;
    }

    public decimal CalculateResourceTotalCost(decimal costPrice, decimal margin)
    {
        // i = s * (1 + m/100)
        return costPrice * (1 + margin / 100);
    }

    public decimal CalculateProjectTotalCost(List<ProjectResource> resources)
    {
        return resources.Sum(r => r.TotalCost);
    }

    public decimal CalculateProjectCostWithTax(decimal totalCost, decimal taxRate)
    {
        // isp = sp + (sp * ns)
        return totalCost + (totalCost * (taxRate / 100));
    }

    public decimal CalculateNetProfit(List<ProjectResource> resources)
    {
        // p = (i - s) + (i - s) .... for each service
        return resources.Sum(r => r.TotalCost - r.CostPrice);
    }
}
