using DataLayer_RPi.Interfaces;
using RaspberryPiNetCore.ADC;

namespace DataLayer_RPi
{
    public class receivesBloodPressureMeasurement : IReceviesBloodPressureMeasurement
    {
        private double voltage;

        public ADC1015 ADC = new ADC1015();
        private List<double> voltages;

        public List<double> MeasureBP()
        {
            voltages = new List<double>();
                        
            for (int i = 0; i < 200; i++)
            {
                ADC.ReadADC_SingleEnded(1);
                ADC.ReadADC_SingleEnded(2);

                voltage = Convert.ToDouble(((ADC.SINGLE_Measurement[2].Take() - ADC.SINGLE_Measurement[1].Take()/ 2048.0))*4.096);

                ADC.Stop_SingleEnded(1);
                ADC.Stop_SingleEnded(2);

                voltages.Add(voltage);
                Thread.Sleep(1);
            }
     

            return voltages;
        }
    }
}