using AVERWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AVERWeb.Data
{
    public class CertificateRepo : ICertificateRepo
    {
        private readonly AppDbContext _context;

        public CertificateRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateCertificate(Certificate certificate)
        {
            if (certificate == null)
                throw new ArgumentNullException(nameof(certificate));
            else
                await _context.AddAsync(certificate);
        }

        public void DeleteCertificate(Certificate certificate)
        {
            if (certificate == null)
                throw new ArgumentNullException(nameof(certificate));
            else
                _context.Certificates.Remove(certificate);
        }

        public async Task<Certificate?> GetCertificate(int id)
        {
            return await _context.Certificates.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Certificate>> GetCertificatesByCashierID(int cashierId)
        {
            return await _context.Certificates.Where(c => c.Id == _context.Cashiers.FirstOrDefault(q => q.Id == cashierId).CertificateId).ToListAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
