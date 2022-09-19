using AVERWeb.Models;

namespace AVERWeb.Data
{
    public interface ICashierRepo
    {
        Task SaveChanges();
        Task CreateCashier(Cashier cashier);
        Task<Cashier?> GetCashierById(int id);
        Task<IEnumerable<Cashier>> GetCashiersByCustomerId(int customerId);
        void DeleteCashier(Cashier cashier);

        bool CashierExist(int id);
    }
}
