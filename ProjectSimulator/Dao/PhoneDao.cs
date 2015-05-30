using System.Collections.Generic;
using ProjectSimulator.Models;
using System.Linq;
using ProjectSimulator.Controllers;

namespace ProjectSimulator.Dao
{
    class PhoneDao
    {
        readonly ApplicationDbContext _db = new ApplicationDbContext();

        public IEnumerable<Phone> GetPhones()
        {
            return _db.Phones;
        }

        public IEnumerable<Phone> GetValidPhones()
        {
            return _db.Phones.Where(p => AllowedPhone.Statuses.Any(s => s == p.State.ToUpper()));
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

        public bool PhoneExists(string imei)
        {
            return _db.Phones.Any(p => p.Imei == imei);
        }
    }
}
