using DataLayer_RPi;
using DataLayer_RPi.Interfaces;
using LogicLayer_RPi;
using LogicLayer_RPi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using RaspberryPiNetCore.ADC;

namespace Blodtryksmaaler_RPi_4.NUnit.test.Test_LogicLayer
{
    [TestFixture]
    public class measurementcontroleRPiUnitTest
    {
        private measurementcontroleRPi uut;
        private IReceviesBloodPressureMeasurement receviesBloodPressure;
        private ISendingBloodPressureMeasurement sendingBloodPressure;
        private IBPCalculator bPCalculator;

        [SetUp]
        public void Setup()
        {
            //Arrange
            receviesBloodPressure = Substitute.For<IReceviesBloodPressureMeasurement>();
            sendingBloodPressure = Substitute.For<ISendingBloodPressureMeasurement>();
            bPCalculator = Substitute.For<IBPCalculator>();

            uut = new measurementcontroleRPi(bPCalculator, receviesBloodPressure, sendingBloodPressure);
        }

        //Det testes om metoden MeasureBP bliver kaldt i datalaget, når metoden GetBPData() i logiklaget kaldes
        [Test]
        public void GetBPData_MeasureBPIsCalled()
        {
            uut.GetBPData();

            receviesBloodPressure.Received(1).MeasureBP();
        }

        //Det testes om metoden SendToPC bliver kaldt i datalaget, når metoden GetBPData() i logiklaget kaldes
        [Test]
        public void GetBPData_SendToPCIsCalled()
        {
            
        }
        [Test]
        public void Test1()
        {
            bool test = true;
            Assert.That(test, Is.EqualTo(true));
        }
    }
    
}
