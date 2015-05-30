using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Owin.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using ProjectSimulator;
using ProjectSimulator.Models;
using System.Net.Http;

namespace ProjectSimulatorTests
{
    [TestFixture]
    public class GetStateFunctionalTest
    {
        private TestServer server;

        [TestFixtureSetUp]
        public void FixtureInit()
        {
            Database.SetInitializer(new TestApplicationDbInitializer());
            TestApplicationDbContext db = new TestApplicationDbContext();
            db.Database.Initialize(true);
            db.Phones.Add(TestDataProvider.GalaxyMini());
            db.SaveChanges();
            server = TestServer.Create<Startup>();
        }

        [TestFixtureTearDown]
        public void FixtureDispose()
        {
            server.Dispose();
        }

        [Test]
        public void WebApiGetAllTest()
        {
            var response = server.HttpClient.GetAsync("api/resaleshop/phones_state").Result;

            var result = response.Content.ReadAsStringAsync().Result;
            var dtos = JsonConvert.DeserializeObject<List<PhoneDto>>(result);

            Assert.That(dtos.Count, Is.EqualTo(1));
            PhoneDto dto = dtos.First();
            Assert.That(dto.State, Is.EqualTo("good"));
            Assert.That(dto.Imei, Is.EqualTo("11112222233333/01"));
        }

        [Test]
        public void WebApiPostPhonesTest()
        {
            var phone1 = new Phone
            {
                Brand = "Samsung",
                Imei = "111113432",
                Model = "Galaxy Mini",
                Year = 2011,
                State ="good"
            };

            var phone2 = new Phone
            {
                Brand = "Samsung 2",
                Imei = "11dsfs1113432",
                Model = "Galaxy Mini",
                Year = 2011,
                State = "very bad"
            };

            var content = new StringContent(JsonConvert.SerializeObject(new List<Phone> { phone1,phone2}));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = server.HttpClient.PostAsync("api/resaleshop/phones",content).Result;

            var result = response.Content.ReadAsStringAsync().Result;
            var dtos = JsonConvert.DeserializeObject<Count>(result);

            Assert.That(dtos.PhonesCount, Is.EqualTo(2));
        }
    }
}
