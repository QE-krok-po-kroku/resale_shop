using System.Data.Entity;
using ProjectSimulator.Models;

namespace ProjectSimulatorTests
{
    public class TestApplicationDbContext : DbContext
    {
        public TestApplicationDbContext() : base("MyDatabase")
        {
        }

        public IDbSet<Phone> Phones { get; set; }
    }

    public class TestApplicationDbInitializer : DropCreateDatabaseAlways<TestApplicationDbContext>
    {
    }
}
