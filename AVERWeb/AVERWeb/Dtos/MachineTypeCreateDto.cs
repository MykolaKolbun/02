using System.ComponentModel.DataAnnotations;
using AVERWeb.Models;
namespace AVERWeb.Dtos
{
    public class MachineTypeCreateDto
    {
        [Required]
        public string? Description { get; set; }
    }
}