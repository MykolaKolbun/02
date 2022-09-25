using AVERWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AVERWeb.Data
{
    public sealed class CashierRepo : ICashierRepo
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


        public void CreateCashier(Cashier cashier)
        {
            if (cashier == null)
                throw new ArgumentNullException(nameof(cashier));
            else
                _context.Cashiers.Add(cashier);
        }

        public void DeleteCashier(Cashier cashier)
        {
            if (cashier is null)
                throw new ArgumentNullException(nameof(cashier));
            else
                _context.Cashiers.Remove(cashier);
        }

        public async Task<Cashier> GetCashierById(int id)
        {
            var cashier = _context.Cashiers.FirstOrDefault(c => c.Id == id);
            if(cashier is not null)
                return await Task.FromResult(cashier);
            else
                throw new NullReferenceException(nameof(id));
        }

        public async Task<IEnumerable<Cashier>> GetCashiersByCustomerId(int customerId)
        {
            var cashiers = _context.Cashiers.Where(c => c.CustomerId == customerId);
            return await Task.FromResult(cashiers);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Cashier GetCashierById2(int Id)
        {
            return _context.Cashiers.FirstOrDefault(c=>c.Id==Id)!;
        }
    }
}
