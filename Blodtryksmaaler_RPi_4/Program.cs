using RaspberryPiNetCore.ADC;
using RaspberryPiNetCore.JoySticks;
using RaspberryPiNetCore.LCD;
using RaspberryPiNetCore.TWIST;
using System;
using LogicLayer_RPi;
using DataLayer_RPi;
using System.Threading;

namespace Raspberry_Pi_Dot_Net_Core_Console_Application3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            measurementcontroleRPi test = new measurementcontroleRPi();
            while(true)
            {
                foreach (double s in test.GetBPData())
                {
                    Console.WriteLine(Convert.ToString(s));
                }

            }
               
        }
    }
}
