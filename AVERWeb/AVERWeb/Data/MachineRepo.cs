using AVERWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AVERWeb.Data
{
    public class MachineRepo : IMachineRepo
    {
        private readonly AppDbContext _context;

        public MachineRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateMachine(Machine machine)
        {
            if (machine == null)
                throw new ArgumentNullException(nameof(machine));
            else
                await _context.AddAsync(machine);
        }

        public void DeleteMachine(Machine machine)
        {
            if (machine == null)
                throw new ArgumentNullException(nameof(machine));
            else
                _context.Machines.Remove(machine);
        }

        public async Task<IEnumerable<Machine>> GetAllMachine()
        {
            return await _context.Machines.ToListAsync();
        }

        public async Task<Machine?> GetMachineById(int id)
        {
            return await _context.Machines.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
