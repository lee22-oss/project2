using ITProjectCalculator.Data.Entities;

namespace ITProjectCalculator.Services.Interfaces;

public interface IEquipmentService
{
    Task<List<Equipment>> GetAllEquipmentAsync();
    Task<Equipment?> GetEquipmentByIdAsync(int id);
    Task<int> CreateEquipmentAsync(Equipment equipment);
    Task<bool> UpdateEquipmentAsync(Equipment equipment);
    Task<bool> DeleteEquipmentAsync(int id);
    Task<decimal> CalculateEquipmentServiceCostAsync(int equipmentServiceId, decimal quantity);
    Task<List<EquipmentService>> GetEquipmentServicesAsync(int equipmentId);
}
