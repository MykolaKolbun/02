using System.ComponentModel.DataAnnotations;

namespace AVERWeb.Models
{
    public sealed class FiscalReceipt
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int DailyId { get; set; }
        public string? FiscalIdOnline { get; set; }
        public string? FiscalIdOffline { get; set; }
        public string? OrderDate { get; set; }
        public string? OrderTime { get; set; }
        public string? Body { get; set; }
        public string? QRCode { get; set; }
        public string? MAC { get; set; }

        public int MachineId { get; set; }
        public Machine? Machine { get; set; }
    }
}