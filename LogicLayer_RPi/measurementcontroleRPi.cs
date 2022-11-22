using DataLayer_RPi;
using DataLayer_RPi.Interfaces;
using LogicLayer_RPi.Interfaces;
using System.Threading;

namespace LogicLayer_RPi
{
    public class measurementcontroleRPi
    {
        IReceviesBloodPressureMeasurement receivesBloodPressure;
        ISendingBloodPressureMeasurement sendingBloodPressure;
        IBPCalculator bPCalculator;
        
        public measurementcontroleRPi(IBPCalculator bPCalculator, IReceviesBloodPressureMeasurement receviesBloodPressure, ISendingBloodPressureMeasurement sendingBloodPressure)
        {
            this.receivesBloodPressure = receviesBloodPressure;
            this.sendingBloodPressure = sendingBloodPressure;
            this.bPCalculator = bPCalculator; 
        }
        public void GetBPData()
        {
            List<double> measurement = new List<double>();

            //De fire beregnede værdier fra BPCalculator tilføjes her
            measurement.Add(0);
            measurement.Add(0);
            measurement.Add(0);
            measurement.Add(0);

            List<double> voltages = receivesBloodPressure.MeasureBP();

            foreach(double voltage in voltages)
            {
                measurement.Add(voltage);
            }

            sendingBloodPressure.SendToPC(measurement);
        }
    }
}