using AVERWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AVERWeb.Data
{
    public class CashierRepo : ICashierRepo
    {
        private readonly AppDbContext _context;

        public CashierRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool CashierExist(int id)
        {
            return _context.Cashiers.Any(p => p.Id == id);
        }

        public async Task CreateCashier(Cashier cashier)
        {
            if (cashier == null)
                throw new ArgumentNullException(nameof(cashier));
            else
                await _context.AddAsync(cashier);
        }

        public void DeleteCashier(Cashier cashier)
        {
            if (cashier == null)
                throw new ArgumentNullException(nameof(cashier));
            else
                _context.Cashiers.Remove(cashier);
        }

        public async Task<Cashier?> GetCashierById(int id)
        {
            return await _context.Cashiers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Cashier>> GetCashiersByCustomerId(int customerId)
        {
            return await _context.Cashiers.Where(c => c.CustomerId == customerId).ToListAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
