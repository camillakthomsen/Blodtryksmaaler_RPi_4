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
        IAlarmChecker alarmChecker;
        
        public measurementcontroleRPi(IBPCalculator bPCalculator, IAlarmChecker alarmChecker)
        {
            receivesBloodPressure = new receivesBloodPressureMeasurement();
            sendingBloodPressure = new sendingBloodPressureMeasurement();
            this.bPCalculator = bPCalculator;
            this.alarmChecker = alarmChecker; 
        }
        public void GetBPData()
        {
            List<double> voltages = new List<double>();

            for (int i = 0; i < 200; i++)
            {
                double voltage = receivesBloodPressure.MeasureBP();
                voltages.Add(voltage);
                Thread.Sleep(5);
            }
            List<double> measurement = new List<double>();

            measurement.Add(alarmChecker.checkAlarm(voltages));
            measurement.Add(bPCalculator.getMiddleBP(voltages));
            measurement.Add(bPCalculator.getDiaBP(voltages));
            measurement.Add(bPCalculator.getSysBP(voltages));

            foreach(double voltage in voltages)
            {
                measurement.Add(voltage);
            }

            sendingBloodPressure.SendToPC(measurement);
        }
    }
}