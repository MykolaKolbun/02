using AVERWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AVERWeb.Data
{
    public class FiscalReceiptRepo : IFiscalReceiptRepo
    {
        private readonly AppDbContext _context;

        public FiscalReceiptRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateFiscalReceipt(FiscalReceipt fiscalReceipt)
        {
            if (fiscalReceipt == null)
                throw new ArgumentNullException(nameof(fiscalReceipt));
            else
                await _context.AddAsync(fiscalReceipt);
        }

        public void DeleteFiscalReceipt(FiscalReceipt fiscalReceipt)
        {
            if (fiscalReceipt == null)
                throw new ArgumentNullException(nameof(fiscalReceipt));
            else
                _context.FiscalReceipts.Remove(fiscalReceipt);
        }

        public async Task<FiscalReceipt?> GetFiscalReceiptById(int id)
        {
            return await _context.FiscalReceipts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
