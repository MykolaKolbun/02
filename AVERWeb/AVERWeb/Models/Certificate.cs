using System.ComponentModel.DataAnnotations;

namespace AVERWeb.Models
{
    public class Certificate
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? PublicCertPath { get; set; }

        [Required]
        public string? PrivateCertPath { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}