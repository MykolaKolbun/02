using AVERWeb.Models;
namespace AVERWeb.Dtos
{
    public class CustomerReadDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? TIN { get; set; }
        public string? EMailAddress { get; set; }
        public string? PhoneNumber { get; set; }
    }
}