using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ProjectSimulator.Dao;
using ProjectSimulator.Models;
using ProjectSimulator.Utils;

namespace ProjectSimulator.Controllers
{
    [RoutePrefix("api/resaleshop/phones_state")]
    public class PhonesStateController : ApiController
    {
        readonly PhoneDao _dao = new PhoneDao();

        [Route("")]
        [HttpGet]
        public IEnumerable<PhoneDto> GetPhonesState()
        {
            return PhoneToPhoneDto.Convert(_dao.GetPhones().ToList());
        }
    }
}
