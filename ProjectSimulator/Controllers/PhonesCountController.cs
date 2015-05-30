using System.Web.Http;
using ProjectSimulator.Dao;
using ProjectSimulator.Models;
using System.Linq;

namespace ProjectSimulator.Controllers
{
    [RoutePrefix("api/resaleshop/phonescount")]
    public class PhonesCountController : ApiController
    {
        readonly PhoneDao _dao = new PhoneDao();

        [Route("")]
        [HttpGet]
        public Count GetPhonesCount()
        {
            var count = _dao.GetValidPhones().Where(p => IsValid(p)).ToList().Count();
            return new Count() {PhonesCount = count};
        }

        private bool IsValid(Phone phone)
        {
            return AllowedPhone.Statuses.Any(s => s == phone.State.ToUpper())
                && !_dao.PhoneExists(phone.Imei) && !string.IsNullOrEmpty(phone.Imei);
        }           
    }
}
