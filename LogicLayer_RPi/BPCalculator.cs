using LogicLayer_RPi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer_RPi
{
    public class BPCalculator : IBPCalculator
    {
        public double systole { get; private set; }
        public double diastole { get; private set; }
        public double middel { get; private set; }
        public int puls { get; private set; }
        public List<double> measurement;

        public void calcAverage(List<double>measurement)
        {
            double totalBP = measurement.Sum();
            int bpDataPoints = measurement.Count();
            double averageBP = totalBP / bpDataPoints;

            getSysBP(bpDataPoints, averageBP);
            getDiaBP(bpDataPoints, averageBP);

            middel = (((systole - diastole) * 1 / 3) + diastole);

        }
        
        public double getSysBP(int bpDataPoints, double averageBP)
        {
            double highLimit = averageBP*1.03;
            double highPeakTotal = 0;
            int highPeakCounter = 0;

            for (int i=0;i<bpDataPoints; i++)
            {
                if(measurement[i]>highLimit&&measurement[i]>measurement[i-1]&&measurement[i]>measurement[i+1])
                {
                    highPeakTotal += measurement[i];
                    highPeakCounter++;
                }
            }

            double sys = highPeakTotal / highPeakCounter;
            systole = sys;
            puls = highPeakCounter;
            return systole;
        }
        public double getDiaBP(int bpDataPoints, double averageBP)
        {
            double lowLimit = averageBP * 0.97;
            double lowPeakTotal = 0;
            int lowPeakCounter = 0;
           

            for (int i = 0; i < bpDataPoints; i++)
            {
                if (measurement[i] < lowLimit && measurement[i] < measurement[i - 1] && measurement[i] < measurement[i + 1])
                {
                    lowPeakTotal += measurement[i];
                    lowPeakCounter++;
                }
            }

            double dia = lowPeakTotal / lowPeakCounter;
            diastole = dia;
            return systole;
        }
        public double getMiddleBP()
        {
            return middel;
        }
        public int getPuls()
        {

            return puls;
        }
    }
}
