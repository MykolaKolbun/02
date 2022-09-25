using AVERWeb.Models;

namespace AVERWeb.Data
{
    public interface IPaymentTypeRepo
    {
        void SaveChanges();
        Task<PaymentType?> GetPaymentTypeById(int id);
        Task<IEnumerable<PaymentType>> GetAllPaymentTypes();
        Task CreatePaymentType(PaymentType paymentType);
        void DeletePaymentType(PaymentType paymentType);
    }
}
