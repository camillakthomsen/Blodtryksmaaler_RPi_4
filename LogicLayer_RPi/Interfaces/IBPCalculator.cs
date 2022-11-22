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
        double getSysBP(int bpDataPoints, double averageB);
        double getDiaBP(int bpDataPoints, double averageBP);
        double getMiddleBP();
        int getPuls();



    }
}
