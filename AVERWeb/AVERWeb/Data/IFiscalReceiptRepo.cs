using AVERWeb.Models;

namespace AVERWeb.Data
{
    public interface IFiscalReceiptRepo
    {
        Task SaveChanges();
        Task CreateFiscalReceipt(FiscalReceipt fiscalReceipt);
        Task<FiscalReceipt?> GetFiscalReceiptById(int id);
        void DeleteFiscalReceipt(FiscalReceipt fiscalReceipt);
    }
}
