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
using NUnit.Framework.Constraints;
using RaspberryPiNetCore.ADC;

namespace Blodtryksmaaler_RPi_4.NUnit.test_LogicLayer
{
    [TestFixture]
    public class measurementcontroleRPiUnitTest
    {
        private measurementcontroleRPi uut;
        private IReceviesBloodPressureMeasurement receviesBloodPressure;
        private ISendingBloodPressureMeasurement sendingBloodPressure;
        private IBPCalculator bPCalculator;
        private List<double> list;

        [SetUp]
        public void Setup()
        {
            //Arrange
            receviesBloodPressure = Substitute.For<IReceviesBloodPressureMeasurement>();
            sendingBloodPressure = Substitute.For<ISendingBloodPressureMeasurement>();
            bPCalculator = Substitute.For<IBPCalculator>();

            uut = new measurementcontroleRPi(bPCalculator, receviesBloodPressure, sendingBloodPressure);
        }
        //Det testes, at der ikke sendes til PC, når uut er oprettet.
        [Test]
        public void SetUpUUT_SendToPCNotCalled()
        {
            sendingBloodPressure.DidNotReceive().SendToPC(list);
        }

        //Det testes, at der ikke hentes målinger, når uut er oprettet.
        [Test]
        public void SetUpUUT_MeasureVPNotCalled()
        {
            receviesBloodPressure.DidNotReceive().MeasureBP();
        }

        //Det testes om metoden MeasureBP bliver kaldt i datalaget, når metoden GetBPData() i logiklaget kaldes
        [TestCase(1, 2, 3, 3, 4, 5, 6)]
        [TestCase(2, 100, -2.3, -1, 10000, 3, 0)]
        [TestCase(10, -1, -3.4444444, 0, 0, 77, 1000.21234)]
        [TestCase(0, 23.23, 8, -100, 2, 7, 3190123.2)]
        public void GetBPData_MeasureBPIsCalled(double a, double b, double c, double d, double e, double f, double g)
        {
            //Arrange
            list = new List<double>();
            list.Add(a);
            list.Add(b);
            list.Add(c);
            list.Add(d);
            list.Add(e);
            list.Add(f);
            list.Add(g);

            receviesBloodPressure.MeasureBP().Returns(list);

            //Act
            uut.GetBPData();

            //Assert
            receviesBloodPressure.Received(1).MeasureBP();
        }

        //Det testes om metoden getValues i BPCalculator i logiklaget bliver kaldt, når metoden GetBPData() i logiklaget kaldes
        [TestCase(1, 2, 3, 3, 4, 5, 6)]
        [TestCase(-1, -2100, -2.3, 232, 90, 6666, 0)]
        [TestCase(1020, -1, -23434.4324234, 0, 0, 77, 121234)]
        [TestCase(0, 233, 811, 0, 221, 78, 322)]
        public void GetBPData_bPCalculatorGetValuesIsCalled(double a, double b, double c, double d, double e, double f, double g)
        {
            //Arrange
            list = new List<double>();
            list.Add(a);
            list.Add(b);
            list.Add(c);
            list.Add(d);
            list.Add(e);
            list.Add(f);
            list.Add(g);
            receviesBloodPressure.MeasureBP().Returns(list);

            //Act
            uut.GetBPData();

            //Assert
            bPCalculator.Received(1).getValues(list);
        }


        //Det testes om metoden SendToPC bliver kaldt i datalaget, når metoden GetBPData() i logiklaget kaldes
        //For at teste de laves et array, som skal simulere 4 beregende værdier. Denne tilføjes til test-listen.
        [TestCase(1, 2, 3, 3, 4, 5, 6,0,0,0,0)]
        [TestCase(231.1, 0, 0, 0, 200, 21, -2222, 1, -1.2, 200, 2323)]
        [TestCase(22123, 20, -2932, 1.2324, 202.210, 1234.21, -2.22, 909.1, -1.2, 200, 0)]
        [TestCase(324124, 2.2, -24, 32, 43201.1, 0.5, 23, 1, 1, 1, 123)]
        public void GetBPData_SendToPCIsCalled(double a, double b, double c, double d, double e, double f, double g,double a1, double a2, double a3, double a4)
        {
            //Arrange
            list = new List<double>();
            list.Add(a);
            list.Add(b);
            list.Add(c);
            list.Add(d);
            list.Add(e);
            list.Add(f);
            list.Add(g);
            receviesBloodPressure.MeasureBP().Returns(list);

            double[] array = new double[4];
            array[0] = a1;
            array[1] = a2;
            array[2] = a3;
            array[3] = a4;
            bPCalculator.getValues(list).Returns(array);

            list.AddRange(array);

            //Act
            uut.GetBPData();
            
            //Assert
            sendingBloodPressure.Received(1).SendToPC(list);
            
        }


        [TestCase(1, 2, 3, 3, 4, 5, 6)]
        public void GetBPDataMoreTimes_MeasureBPIsCalledMoreTimes(double a, double b, double c, double d, double e,
            double f, double g)
        {
            //Arrange
            list = new List<double>();
            list.Add(a);
            list.Add(b);
            list.Add(c);
            list.Add(d);
            list.Add(e);
            list.Add(f);
            list.Add(g);
            receviesBloodPressure.MeasureBP().Returns(list);

            //Act
            uut.GetBPData();
            uut.GetBPData();

            //Assert
            receviesBloodPressure.Received(2).MeasureBP();
        }
    }


}
