using System.Collections.Generic;
using ProjectSimulator.Models;

namespace ProjectSimulator.Dao
{
    class PhoneDao
    {
        readonly ApplicationDbContext _db = new ApplicationDbContext();

        public IEnumerable<Phone> GetPhones()
        {
            return _db.Phones;
        }

        public void AddPhone(Phone phone)
        {
            _db.Phones.Add(phone);
            _db.SaveChanges();
        }

        public void ResetDatabase()
        {
            _db.Database.Initialize(true);
        }
    }
}
