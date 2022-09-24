using AVERWeb.Models;

namespace AVERWeb.Data
{
    public interface ICustomerRepo
    {
        void SaveChanges();
        Task<Customer?> GetCustomerById(int id);
        Task<Customer?> GetCustomerByName(string name);
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task CreateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);

    }
}
