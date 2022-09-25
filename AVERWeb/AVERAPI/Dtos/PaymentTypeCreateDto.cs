using System.ComponentModel.DataAnnotations;
using AVERWeb.Models;
namespace AVERWeb.Dtos
{
    public class PaymentTypeCreateDto
    {
        [Required]
        public string? Description { get; set; } 
    }
}