using System.Collections.Generic;
using ProjectSimulator.Models;

namespace ProjectSimulator.Utils
{
    public class PhoneToPhoneDto
    {
        public static IList<PhoneDto> Convert(IList<Phone> Phones)
        {
            IList<PhoneDto> result  = new List<PhoneDto>();
            foreach (var Phone in Phones)
            {
                result.Add(new PhoneDto
                {
                    Imei = Phone.Imei,
                    State = Phone.State
                });
            }
            return result;
        }
    }
}
