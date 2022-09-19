using AVERWeb.Models;
namespace AVERWeb.Dtos
{
    public class CertificateReadDto
    {
        public int Id { get; set; }
        public string? PublicKeyPath { get; set; }
        public string? PrivateKeyPath { get; set; }
        public string? Pass { get; set; }
    }
}