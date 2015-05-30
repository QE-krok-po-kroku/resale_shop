using System.Data.Entity;

namespace ProjectSimulator.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("MyDatabase") {}

        public IDbSet<Phone> Phones { get; set; }
    }

    public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);

            var phones = new Phone[]
            {
                new Phone
                {
                    Imei = "11112222233333/01",
                    Model = "Galaxy Mini",
                    Brand = "Samsung",
                    Year = 2011,
                    State = "BAD"
                },
                new Phone
                {
                    Imei = "42343242343423/02",
                    Model = "One",
                    Brand = "HTC",
                    Year = 2010,
                    State = "VERY_BAD"
                }
            };

            foreach (var phone in phones)
            {
                context.Phones.Add(phone);
            }
        }
    }
}
