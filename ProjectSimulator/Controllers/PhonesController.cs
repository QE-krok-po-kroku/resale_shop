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
            return _dao.GetValidPhones();
        }

        //TODO: Sprint 1
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] List<Phone> phones)
        {
            var validPhones = phones.Where(p => IsValid(p)).ToList();
            foreach (var phone in validPhones)
            {
                phone.State = phone.State.ToUpper();
                _dao.AddPhone(phone);                    
            }
            if (validPhones.Count() == 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var count = _dao.GetValidPhones().Count();
            return Request.CreateResponse(HttpStatusCode.Created, new Count() { PhonesCount = count });
        }

        private bool IsValid(Phone phone)
        {
            return AllowedPhone.Statuses.Any(s => s == phone.State.ToUpper())
                && !_dao.PhoneExists(phone.Imei) && !string.IsNullOrEmpty(phone.Imei);
        }           

    }
}
