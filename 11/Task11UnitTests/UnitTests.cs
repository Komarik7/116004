using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task11;
using NUnit.Framework;

namespace Task11UnitTests
{
    [TestFixture]
    class UnitTests
    {
        private List<string> testPlan = new List<string> { "Стамбул", "Анталья" };
        private Tour CreateTestTour()
        {
            return new Tour("Турция2022", 228, testPlan, TransportType.plane, 21);
        }
        [Test]
        public void ConstructorTest()
        {
            var tour = CreateTestTour();
            Assert.AreEqual("Турция2022", tour.Name);
            Assert.AreEqual(228,tour.Code);
            Assert.AreEqual(testPlan,tour.Plan);
            Assert.AreEqual(TransportType.plane, tour.Transport);
            Assert.AreEqual(21, tour.Dur);
        }
        [Test]
        public void ToString_Tour_NameSpaceCode()
        {
            var tour = CreateTestTour();
            Assert.AreEqual("Турция2022 228", tour.ToString());
        }
    }
}
