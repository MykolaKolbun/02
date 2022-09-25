using AVERWeb.Models;

namespace AVERWeb.Data
{
    public interface IMachineRepo
    {
        void SaveChanges();
        Task CreateMachine(Machine machine);
        Task <IEnumerable<Machine>>GetAllMachine();
        Task<Machine?> GetMachineById(int id);
        void DeleteMachine(Machine machine);
    }
}
