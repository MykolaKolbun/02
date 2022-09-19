using System.ComponentModel.DataAnnotations;

namespace AVERWeb.Models
{
    public class Machine
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }

        public int MachineTypeId { get; set; }
        public MachineType? MachineType { get; set; }
        
        public int CashierId { get; set; }
        public Cashier? Cashier { get; set; }
    }
}