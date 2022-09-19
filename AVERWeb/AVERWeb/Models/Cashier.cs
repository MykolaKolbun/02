using System.ComponentModel.DataAnnotations;

namespace AVERWeb.Models
{
    public class Cashier
    {

        // Scalar Properties ---------------------------------------
        public int Id { get; set; }
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }
        public string? TIN { get; set; }

        // Reference Navigation Property -----------------------------------
        public int CertificateId { get; set; }
        public Certificate? Certificate { get; set; }
        
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}