using DataLayer_RPi;
using System.Threading;

namespace LogicLayer_RPi
{
    public class measurementcontroleRPi
    {
        receivesBloodPressureMeasurement receivesBloodPressure;
        List<double> voltages;
        public measurementcontroleRPi()
        {
            receivesBloodPressure = new receivesBloodPressureMeasurement();
        }
        public List<double> GetBPData()
        {
            voltages = new List<double>();

            for(int i = 0; i < 200; i++)
            {
                double voltage = receivesBloodPressure.MeasureBP();
                voltages.Add(voltage);
                Thread.Sleep(5);

            }
       
            return voltages;
        }
    }
}