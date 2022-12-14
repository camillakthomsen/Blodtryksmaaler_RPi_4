using System;
using LogicLayer_RPi;
using System.Threading;
using DataLayer_RPi.Interfaces;
using DataLayer_RPi;

namespace Raspberry_Pi_Dot_Net_Core_Console_Application3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Blodtryksmåling i gang");
            
            IReceviesBloodPressureMeasurement receviesBloodPressureMeasurement = new receivesBloodPressureMeasurement();
            ISendingBloodPressureMeasurement sendingBloodPressureMeasurement = new sendingBloodPressureMeasurement();
            measurementcontroleRPi test = new measurementcontroleRPi(receviesBloodPressureMeasurement, sendingBloodPressureMeasurement); ;

            while(true)
            {
                test.GetBPData();
            }
        }
    }
}
