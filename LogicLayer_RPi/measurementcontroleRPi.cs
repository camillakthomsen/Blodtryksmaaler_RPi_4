using DataLayer_RPi;
using DataLayer_RPi.Interfaces;
using System.Threading;

namespace LogicLayer_RPi
{
    public class measurementcontroleRPi
    {
        IReceviesBloodPressureMeasurement receivesBloodPressure;
        ISendingBloodPressureMeasurement sendingBloodPressure;
        
        public measurementcontroleRPi(IReceviesBloodPressureMeasurement receviesBloodPressure, ISendingBloodPressureMeasurement sendingBloodPressure)
        {
            this.receivesBloodPressure = receviesBloodPressure;
            this.sendingBloodPressure = sendingBloodPressure;
        }
        public void GetBPData()
        {
            List<double> voltages = receivesBloodPressure.MeasureBP();

            foreach (double voltage in voltages)
            {
                Console.WriteLine(Convert.ToString(voltage));
            }

            sendingBloodPressure.SendToPC(voltages);
        }
    }
}