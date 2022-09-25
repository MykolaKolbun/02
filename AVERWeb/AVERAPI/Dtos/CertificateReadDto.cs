using AVERWeb.Models;
namespace AVERWeb.Dtos
{
    public class CertificateReadDto
    {
        public int Id { get; set; }
        public string? PublicCertPath { get; set; }
        public string? PrivateCertPath { get; set; }
        public string? Password { get; set; }
    }
}