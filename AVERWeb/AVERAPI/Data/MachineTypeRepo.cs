using AVERWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AVERWeb.Data
{
    public class MachineTypeRepo : IMachineTypeRepo
    {
        private readonly AppDbContext _context;

        public MachineTypeRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateMachineType(MachineType machineType)
        {
            if (machineType == null)
                throw new ArgumentNullException(nameof(machineType));
            else
                await _context.AddAsync(machineType);
        }

        public void DeleteMachineType(MachineType machineType)
        {
            if (machineType == null)
                throw new ArgumentNullException(nameof(machineType));
            else
                _context.MachineTypes.Remove(machineType);
        }

        public async Task<IEnumerable<MachineType>> GetAllMachineTypes()
        {
            return await _context.MachineTypes.ToListAsync();
        }

        public async Task<MachineType?> GetMachineTypeById(int id)
        {
            return await _context.MachineTypes.FirstOrDefaultAsync(c => c.Id==id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
