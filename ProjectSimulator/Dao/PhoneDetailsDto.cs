using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSimulator.Dao
{
    public class PhoneDetailsDto
    {
        public string Imei { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public string State { get; set; }
    }
}
