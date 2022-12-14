using DataLayer_RPi.Interfaces;
using RaspberryPiNetCore.ADC;

namespace DataLayer_RPi
{
    public class receivesBloodPressureMeasurement : IReceviesBloodPressureMeasurement
    {
       private ADC1015 ADC = new ADC1015(/*72, 313*/);
       private List<double> voltages;

       public receivesBloodPressureMeasurement()
       {
           ADC.SamplingsRate = 150;
       }

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
                //Console.WriteLine(kanal2);
                //Console.WriteLine(kanal1);

            //    double voltage = Convert.ToDouble(((kanal2 - kanal1) / 2048.0) * 2.048);
            //    Console.WriteLine(voltage);

                voltages.Add(voltage);
                //Thread.Sleep(5);
            }

   


            return voltages;
        }
    }
}
