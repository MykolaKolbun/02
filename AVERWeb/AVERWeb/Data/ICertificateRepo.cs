﻿using AVERWeb.Models;

namespace AVERWeb.Data
{
    public interface ICertificateRepo
    {
        Task SaveChanges();
        Task<Certificate?> GetCertificate(int id);
        Task<IEnumerable<Certificate>> GetCertificatesByCashierID(int cashierId);
        Task CreateCertificate(Certificate certificate);
        void DeleteCertificate(Certificate certificate);
    }
}
