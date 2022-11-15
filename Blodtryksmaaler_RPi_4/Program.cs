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
            Console.WriteLine("Hello World!");

            IBPCalculator bPCalculator = new BPCalculator();

            measurementcontroleRPi test = new measurementcontroleRPi(bPCalculator);

            while(true)
            {
                test.GetBPData();
            }
               
        }
    }
}
