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
            
            List<double> voltages = receivesBloodPressure.MeasureBP();
            List<double> measurement = voltages;

            double[] values = bPCalculator.getValues(voltages);

            //De fire beregnede værdier fra BPCalculator tilføjes her
            measurement.AddRange(values);

            sendingBloodPressure.SendToPC(measurement);
        }
    }
}