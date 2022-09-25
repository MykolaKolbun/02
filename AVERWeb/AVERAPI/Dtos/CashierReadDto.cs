using AVERWeb.Models;
namespace AVERWeb.Dtos
{
    public class CashierReadDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? TIN { get; set; }

        public int CertificateId { get; set; }
        public Certificate? Certificate { get; set; }
        
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}