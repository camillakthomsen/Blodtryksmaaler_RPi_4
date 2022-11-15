using DataLayer_RPi;
using LogicLayer_RPi.Interfaces;
using System.Threading;

namespace LogicLayer_RPi
{
    public class measurementcontroleRPi
    {
        receivesBloodPressureMeasurement receivesBloodPressure;
        sendingBloodPressureMeasurement sendingBloodPressure;
        IBPCalculator BPCalculator;
        
        public measurementcontroleRPi(IBPCalculator bPCalculator)
        {
            receivesBloodPressure = new receivesBloodPressureMeasurement();
            sendingBloodPressure = new sendingBloodPressureMeasurement();
            BPCalculator = bPCalculator;
        }
        public void GetBPData()
        {
            List<double> voltages = new List<double>();

            voltages.Add(BPCalculator.getMiddleBP());
            voltages.Add(BPCalculator.getDiaBP());
            voltages.Add(BPCalculator.getSysBP());

            for (int i = 0; i < 200; i++)
            {
                double voltage = receivesBloodPressure.MeasureBP();
                voltages.Add(voltage);
                Thread.Sleep(5);
            }
            sendingBloodPressure.SendToPC(voltages);
        }
    }
}