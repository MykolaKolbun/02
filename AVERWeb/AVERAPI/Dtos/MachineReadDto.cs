using AVERWeb.Models;
namespace AVERWeb.Dtos
{
    public class MachineReadDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int MachineTypeId { get; set; }
        public MachineType? MachineType { get; set; }
        
        public int CashierId { get; set; }
        public Cashier? Cashier { get; set; }
    }
}