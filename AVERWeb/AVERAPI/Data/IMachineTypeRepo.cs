using AVERWeb.Models;

namespace AVERWeb.Data
{
    public interface IMachineTypeRepo
    {
        void SaveChanges();
        Task<MachineType?> GetMachineTypeById(int id);
        Task<IEnumerable<MachineType>> GetAllMachineTypes();
        Task CreateMachineType(MachineType machineType);
        void DeleteMachineType(MachineType machineType);
    }
}
