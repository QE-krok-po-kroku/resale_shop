using ProjectSimulator.Models;

namespace ProjectSimulatorTests
{
    public class TestDataProvider
    {
        public static Phone GalaxyMini(string state = "good")
        {
            return new Phone
            {
                Imei = "11112222233333/01",
                Model = "Galaxy Mini",
                Brand = "Samsung",
                Year = 2011,
                State = state
            };
        }
    }
}
