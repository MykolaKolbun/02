using AVERWeb.Models;
namespace AVERWeb.Dtos
{
    public class CertificateCreateDto
    {
        public string? PublicKeyPath { get; set; }
        public string? PrivateKeyPath { get; set; }
        public string? Pass { get; set; }
    }
}