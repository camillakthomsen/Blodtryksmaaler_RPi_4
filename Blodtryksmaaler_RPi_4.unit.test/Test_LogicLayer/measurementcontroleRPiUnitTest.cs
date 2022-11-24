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

namespace Blodtryksmaaler_RPi_4.NUnit.test.Test_LogicLayer
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

            list = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }
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
        [Test]
        public void GetBPData_bPCalculatorGetValuesIsCalledd()
        {
            receviesBloodPressure.MeasureBP().Returns(list);

            uut.GetBPData();

            receviesBloodPressure.Received(1).MeasureBP();
        }

        //Det testes om metoden getValues i BPCalculator i logiklaget bliver kaldt, når metoden GetBPData() i logiklaget kaldes
        [Test]
        public void GetBPData_bPCalculatorGetValuesIsCalled()
        {
            receviesBloodPressure.MeasureBP().Returns(list);

            uut.GetBPData();

            bPCalculator.Received(1).getValues(list);
        }


        //Det testes om metoden SendToPC bliver kaldt i datalaget, når metoden GetBPData() i logiklaget kaldes
        //For at teste de laves et array på fire 0'er, som skal simulere 4 beregende værdier.
        [Test]
        public void GetBPData_SendToPCIsCalled()
        {
            double[] array = new double[4];
            array[0] = 0;
            array[1] = 0;
            array[2] = 0;
            array[3] = 0;


            receviesBloodPressure.MeasureBP().Returns(list);
            bPCalculator.getValues(list).Returns(array);
            uut.GetBPData();

            list.Add(0);
            list.Add(0);
            list.Add(0);
            list.Add(0);
            
            sendingBloodPressure.Received(1).SendToPC(list);
            
        }
        
    }
    
}
