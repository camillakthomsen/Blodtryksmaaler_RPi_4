using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer_RPi.Interfaces
{
    public interface IBPCalculator
    {
        double getMiddleBP(List<double> measurement);
        double getSysBP(List<double> measurement);
        double getDiaBP(List<double> measurement);

        double getPuls(List<double> measurement);

    }
}
