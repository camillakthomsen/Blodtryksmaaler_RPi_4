using DataLayer_RPi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blodtryksmaaler_RPi_4.NUnit.test_DataLayer
{
    [TestFixture]
    public class sendingBloodPressureMeasurementUnitTest
    {
        private sendingBloodPressureMeasurement uut;
        [SetUp]
        public void Setup()
        {
            //Arrange
            uut = new sendingBloodPressureMeasurement();
        }

        [Test]
        public void Test1()
        {
            bool test = true;
            Assert.That(test, Is.EqualTo(true));
        }
    }
}
