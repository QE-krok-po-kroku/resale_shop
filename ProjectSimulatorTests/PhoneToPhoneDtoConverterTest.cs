using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ProjectSimulator.Models;
using ProjectSimulator.Utils;

namespace ProjectSimulatorTests
{
    [TestFixture]
    public class PhoneToPhoneDtoConverterTest
    {
        [Test]
        public void ShouldReturnEmptyListWhenEmptyListPassed()
        {
            IList<Phone> phones = new List<Phone>();

            IList<PhoneDto> dtos = PhoneToPhoneDto.Convert(phones);

            Assert.That(dtos, Is.Empty);
        }

        [Test]
        public void ShouldConvertPhoneIntoPhoneDto()
        {
            IList<Phone> phones = new List<Phone>();
            phones.Add(TestDataProvider.GalaxyMini());

            IList<PhoneDto> dtos = PhoneToPhoneDto.Convert(phones);

            Assert.That(dtos.Count, Is.EqualTo(1));
            PhoneDto dto = dtos.First();
            Assert.That(dto.Imei, Is.EqualTo("11112222233333/01"));
            Assert.That(dto.State, Is.EqualTo("good"));
        }
    }
}
