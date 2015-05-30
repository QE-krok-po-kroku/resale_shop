using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using ProjectSimulator.Models;
using ProjectSimulator.Dao;

namespace ProjectSimulator.Controllers
{
    [RoutePrefix("api/resaleshop/phones")]
    public class PhonesController : ApiController
    {
        readonly PhoneDao _dao = new PhoneDao();

        [Route("")]
        [HttpGet]
        public IEnumerable<Phone> GetPhones()
        {
            //TODO: Sprint 2
            return new List<Phone>();
        }

        //TODO: Sprint 1
                [Route("")]
                [HttpPost]
                public HttpResponseMessage Post([FromBody] Phone phone)
                {
                    _dao.AddPhone(phone);
                    var count = _dao.GetPhones().Count();
                    return Request.CreateResponse(HttpStatusCode.Created, new Count() { PhonesCount = count});
                }
    }
}
