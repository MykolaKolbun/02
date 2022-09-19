using System.ComponentModel.DataAnnotations;
using AVERWeb.Models;
namespace AVERWeb.Dtos
{
    public class PaymentTypeUpdateDto
    {
        [Required]
        public string? Description { get; set; } 
    }
}