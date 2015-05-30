﻿using System.Collections.Generic;
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
            return _dao.GetPhones().Where(p => p.State != "very_bad");
        }

        //TODO: Sprint 1
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] List<Phone> phones)
        {
            foreach (var phone in phones)
            {
                if(IsValid(phone))
                    _dao.AddPhone(phone);
            }
            var count = _dao.GetPhones().Count();
            return Request.CreateResponse(HttpStatusCode.Created, new Count() { PhonesCount = count });
        }

        private bool IsValid(Phone phone)
        {
            return _allwedStatuses.Any(s => s == phone.State.ToUpper());
        }

        private IList<string> _allwedStatuses = new List<string>
        {
            "NEW",
            "GOOD",
            "BAD"
        };
    }
}
