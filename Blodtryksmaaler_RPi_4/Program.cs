using System;
using LogicLayer_RPi;
using System.Threading;
using LogicLayer_RPi.Interfaces;

namespace Raspberry_Pi_Dot_Net_Core_Console_Application3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Blodtryksmåling i gang");

            IBPCalculator bPCalculator = new BPCalculator();
            IAlarmChecker alarmChecker = new AlarmChecker();

            measurementcontroleRPi test = new measurementcontroleRPi(bPCalculator, alarmChecker);

            while(true)
            {
                test.GetBPData();
            }
               
        }
    }
}
