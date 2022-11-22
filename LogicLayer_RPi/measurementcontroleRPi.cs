using DataLayer_RPi;
using LogicLayer_RPi.Interfaces;
using System.Threading;

namespace LogicLayer_RPi
{
    public class measurementcontroleRPi
    {
        receivesBloodPressureMeasurement receivesBloodPressure;
        sendingBloodPressureMeasurement sendingBloodPressure;
        IBPCalculator bPCalculator;
        
        public measurementcontroleRPi(IBPCalculator bPCalculator)
        {
            receivesBloodPressure = new receivesBloodPressureMeasurement();
            sendingBloodPressure = new sendingBloodPressureMeasurement();
            this.bPCalculator = bPCalculator; 
        }
        public void GetBPData()
        {
            List<double> voltages = new List<double>();

            for (int i = 0; i < 200; i++)
            {
                double voltage = receivesBloodPressure.MeasureBP();
                voltages.Add(voltage);
                Thread.Sleep(1);
            }
            List<double> measurement = new List<double>();

            measurement.Add(0);
            measurement.Add(0);
            measurement.Add(0);
            measurement.Add(0);

            foreach(double voltage in voltages)
            {
                measurement.Add(voltage);
            }

            sendingBloodPressure.SendToPC(measurement);
        }
    }
}