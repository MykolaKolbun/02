using AVERWeb.Models;

namespace AVERWeb.Data
{
    public interface IMachineRepo
    {
        Task SaveChanges();
        Task CreateMachine(Machine machine);
        Task <IEnumerable<Machine>>GetAllMachine();
        Task<Machine?> GetMachineById(int id);
        void DeleteMachine(Machine machine);
    }
}
