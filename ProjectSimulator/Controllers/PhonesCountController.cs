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
            var count = _dao.GetValidPhones().Count();
            return new Count() {PhonesCount = count};
        }
    }
}
