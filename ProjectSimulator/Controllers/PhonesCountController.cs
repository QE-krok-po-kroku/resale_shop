using System.Web.Http;
using ProjectSimulator.Dao;
using ProjectSimulator.Models;

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
            //TODO: Sprint 3
            return new Count() {PhonesCount = 0};
        }
    }
}
