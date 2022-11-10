using RaspberryPiNetCore.ADC;

namespace DataLayer_RPi
{
    public class receivesBloodPressureMeasurement
    {
        double spaending;

        ADC1015 ADC = new ADC1015();

        public double MeasureBP()
        {

                ADC.ReadADC_SingleEnded(1);
                spaending = Convert.ToDouble((ADC.SINGLE_Measurement[1].Take() / 2048.0) * 6.144);

                
                ADC.Stop_SingleEnded(1);

                return spaending;


        }
    }
}