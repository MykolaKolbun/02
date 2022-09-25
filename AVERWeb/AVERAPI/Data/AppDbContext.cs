using AVERWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AVERWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Cashier> Cashiers  => Set<Cashier>();
        public DbSet<Certificate> Certificates => Set<Certificate>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<FiscalReceipt> FiscalReceipts => Set<FiscalReceipt>();
        public DbSet<Machine> Machines => Set<Machine>();
        public DbSet<MachineType> MachineTypes => Set<MachineType>();
        public DbSet<PaymentType> PaymentTypes => Set<PaymentType>();
    }
}