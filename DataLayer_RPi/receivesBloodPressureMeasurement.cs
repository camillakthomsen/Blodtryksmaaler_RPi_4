using DataLayer_RPi.Interfaces;
using RaspberryPiNetCore.ADC;

namespace DataLayer_RPi
{
    public class receivesBloodPressureMeasurement : IReceviesBloodPressureMeasurement
    {
       private ADC1015 ADC = new ADC1015(72, 0x0400);
       private List<double> voltages;

       
        public List<double> MeasureBP()
        {
            voltages = new List<double>();
            ADC.SamplingsRate = 200;

            ADC.ReadADC_SingleEnded(1);
            ADC.ReadADC_SingleEnded(2);

            for (int i = 0; i < 200; i++)
            {
               
                var kanal2 = ADC.SINGLE_Measurement[2].Take();
                var kanal1 = ADC.SINGLE_Measurement[1].Take();

                //Console.WriteLine((kanal2 / 2048.0) * 2.048);
                //Console.WriteLine((kanal1 / 2048.0) * 2.048);

                double voltage = Convert.ToDouble(((kanal2 - kanal1) / 2048.0) * 2.048);
                //Console.WriteLine(voltage);
                
                voltages.Add(voltage);
                //Thread.Sleep(5);
            }

            return voltages;
        }
    }
}
