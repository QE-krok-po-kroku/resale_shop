using System.ComponentModel.DataAnnotations;

namespace ProjectSimulator.Models
{
    public class Phone
    {
        [Key]
        public string Imei { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public string State { get; set; }
    }
}
