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

            //ADC.ReadADC_SingleEnded(3);

            //Console.WriteLine((ADC.SINGLE_Measurement[3].Take() / 2048.0) * 2.048);
            //Console.WriteLine("test");

            //ADC.Stop_SingleEnded(3);
            //Thread.Sleep(1000);
            
            for (int i = 0; i < 200; i++)
            {
                ADC.ReadADC_Differential_2_3();
                Console.WriteLine((ADC.DIFFERENCE_Measurement[3].Take() / 2048.0) * 2.048);
                ADC.Stop_Differential_2_3();
                
                Thread.Sleep(5);
            }

            //ADC.ReadADC_Differential_0_1();
            //for (int i = 0; i < 100; i++)
            //{
            //    //var kanal1 = ADC.DIFFERENCE_Measurement[0].Take();
            //    var kanal2 = ADC.DIFFERENCE_Measurement[0].Take();
            //    //Console.WriteLine(kanal2);
            //    //Console.WriteLine(kanal1);

            //    //double voltage = Convert.ToDouble(((kanal2 - kanal1) / 2048.0) * 2.048);
            //    //Console.WriteLine(voltage);

            //    Console.WriteLine(Convert.ToString((kanal2 / 2048.0) * 2.048));

            //    //voltages.Add(voltage);
            //    //Thread.Sleep();
            //}
            //ADC.Stop_Diffential_0_1();


            //for (int i = 0; i < 100; i++)
            //{
            //    ADC.ReadADC_Differential_0_1();
            //    var kanal2 = ADC.SINGLE_Measurement[2].Take();
            //    var kanal1 = ADC.SINGLE_Measurement[1].Take();
            //    //Console.WriteLine(kanal2);
            //    //Console.WriteLine(kanal1);

            //    double voltage = Convert.ToDouble(((kanal2 - kanal1) / 2048.0) * 2.048);
            //    Console.WriteLine(voltage);

            //    ADC.Stop_SingleEnded(1);
            //    ADC.Stop_SingleEnded(2);

            //    voltages.Add(voltage);
            //    //Thread.Sleep();
            //}


            return voltages;
        }
    }
}
