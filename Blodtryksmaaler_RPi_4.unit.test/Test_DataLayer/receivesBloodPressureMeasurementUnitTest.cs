using DataLayer_RPi;
using RaspberryPiNetCore.ADC;

namespace Blodtryksmaaler_RPi_4.NUnit.test_DataLayer
{
    [TestFixture]
    public class receivesBloodPressureMeasurementUnitTest
    {
        private receivesBloodPressureMeasurement uut;
        [SetUp]
        public void Setup()
        {
            //Arrange
            uut = new receivesBloodPressureMeasurement();
        }

        [Test]
        public void Test1()
        {
            bool test = true;
            Assert.That(test, Is.EqualTo(true));
        }
    }
}