using AVERWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AVERWeb.Data
{
    public class PaymentTypeRepo : IPaymentTypeRepo
    {
        private readonly AppDbContext _context;

        public PaymentTypeRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreatePaymentType(PaymentType paymentType)
        {
            if (paymentType == null)
                throw new ArgumentNullException(nameof(paymentType));
            else
                await _context.AddAsync(paymentType);
        }

        public void DeletePaymentType(PaymentType paymentType)
        {
            if (paymentType == null)
                throw new ArgumentNullException(nameof(paymentType));
            else
                _context.PaymentTypes.Remove(paymentType);
        }

        public async Task<IEnumerable<PaymentType>> GetAllPaymentTypes()
        {
            return await _context.PaymentTypes.ToListAsync();
        }

        public async Task<PaymentType?> GetPaymentTypeById(int id)
        {
            return await _context.PaymentTypes.FirstOrDefaultAsync(c => c.Id == id);
        }

        public void SaveChanges()
        {
             _context.SaveChanges();
        }
    }
}
