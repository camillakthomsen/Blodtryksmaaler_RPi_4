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
                ADC.ReadADC_SingleEnded(0);
                ADC.ReadADC_SingleEnded(1);

                voltage = Convert.ToDouble(ADC.SINGLE_Measurement[1].Take() - ADC.SINGLE_Measurement[0].Take());

                ADC.Stop_SingleEnded(0);
                ADC.Stop_SingleEnded(1);

                voltages.Add(voltage);
                Thread.Sleep(1);
            }
     

            return voltages;
        }
    }
}