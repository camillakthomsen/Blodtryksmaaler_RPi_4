using DataLayer_RPi.Interfaces;
using RaspberryPiNetCore.ADC;

namespace DataLayer_RPi
{
    public class receivesBloodPressureMeasurement : IReceviesBloodPressureMeasurement
    {
       private ADC1015 ADC = new ADC1015(/*72,313*/);
        private List<double> voltages;

        public List<double> MeasureBP()
        {
            voltages = new List<double>();
                        
            for (int i = 0; i < 200; i++)
            {
                ADC.ReadADC_SingleEnded(1);
                ADC.ReadADC_SingleEnded(2);

                double voltage = Convert.ToDouble(((ADC.SINGLE_Measurement[2].Take() - ADC.SINGLE_Measurement[1].Take()) / 2048.0) * 2.048);

                ADC.Stop_SingleEnded(1);
                ADC.Stop_SingleEnded(2);

                voltages.Add(voltage);
                Thread.Sleep(5);
            }


            return voltages;
        }
    }
}
