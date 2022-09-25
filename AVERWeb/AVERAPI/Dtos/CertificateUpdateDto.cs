using AVERWeb.Models;
namespace AVERWeb.Dtos
{
    public class CertificateUpdateDto
    {
        public string? PublicCertPath { get; set; }
        public string? PrivateCertPath { get; set; }
        public string? Password { get; set; }
    }
}