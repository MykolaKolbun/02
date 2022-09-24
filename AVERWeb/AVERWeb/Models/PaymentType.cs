using System.ComponentModel.DataAnnotations;

namespace AVERWeb.Models
{
    public sealed class PaymentType
    {
        public int Id { get; set; } 
        [Required]
        public string? Description { get; set; } 
    }
}