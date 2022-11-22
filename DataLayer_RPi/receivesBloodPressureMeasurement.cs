using DataLayer_RPi.Interfaces;
using RaspberryPiNetCore.ADC;

namespace DataLayer_RPi
{
    public class receivesBloodPressureMeasurement : IReceviesBloodPressureMeasurement
    {
        private double voltage;

        private ADC1015 ADC;
        private List<double> voltages;

        public receivesBloodPressureMeasurement()
        {
            ADC = new ADC1015();
        }

        public List<double> MeasureBP()
        {
            voltages = new List<double>();
                        
            for (int i = 0; i < 200; i++)
            {
                ADC.ReadADC_SingleEnded(0);
                ADC.ReadADC_SingleEnded(1);

                voltage = Convert.ToDouble((ADC.SINGLE_Measurement[1].Take()/* / 2048.0) * 6.144*/));

                ADC.Stop_SingleEnded(0);
                ADC.Stop_SingleEnded(1);

                voltages.Add(voltage);
                Thread.Sleep(1);
            }
     

            return voltages;
        }
    }
}