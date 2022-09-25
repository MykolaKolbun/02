using System.ComponentModel.DataAnnotations;
using AVERWeb.Models;
namespace AVERWeb.Dtos
{
    public class MachineTypeUpdateDto
    {
        [Required]
        public string? Description { get; set; }
    }
}