using System.Collections.Generic;
using ProjectSimulator.Models;
using ProjectSimulator.Dao;

namespace ProjectSimulator.Utils
{
    public class PhoneToPhoneDetailsDaoDto
    {
        public static IList<PhoneDetailsDto> Convert(IList<Phone> Phones)
        {
            IList<PhoneDetailsDto> result = new List<PhoneDetailsDto>();
            foreach (var Phone in Phones)
            {
                result.Add(new PhoneDetailsDto
                {
                    Imei = Phone.Imei,
                    State = Phone.State
                });
            }
            return result;
        }
    }
}
