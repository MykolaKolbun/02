using AVERWeb.Models;

namespace AVERWeb.Data
{
    public interface ICashierRepo
    {
        void SaveChanges();
        void CreateCashier(Cashier cashier);
        Task<Cashier> GetCashierById(int id);

        Cashier GetCashierById2(int id);
        Task<IEnumerable<Cashier>> GetCashiersByCustomerId(int customerId);

        //IEnumerable<Cashier> GetCashiersByCustomerId(int customerId);
        void DeleteCashier(Cashier cashier);

        bool CashierExist(int id);
    }
}
