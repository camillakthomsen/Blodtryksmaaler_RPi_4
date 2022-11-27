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
using System.Diagnostics.Metrics;
using NUnit.Framework.Internal;

namespace Blodtryksmaaler_RPi_4.NUnit.test_LogicLayer
{
    [TestFixture]
    public class BPCalculatorUnitTest
    {
        private BPCalculator uut;
        [SetUp]
        public void Setup()
        {
            //Arrange
            uut = new BPCalculator();
        }

        [Test]
        public void Test1()
        {

        }

    }
}

