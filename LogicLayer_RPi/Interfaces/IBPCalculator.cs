using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer_RPi.Interfaces
{
    public interface IBPCalculator
    {
        void calcAverage(List<double> measurement);
        void getSysBP(int bpDataPoints, double averageB);
        void getDiaBP(int bpDataPoints, double averageBP);
        double[] getValues(List<double> measurement);



    }
}
