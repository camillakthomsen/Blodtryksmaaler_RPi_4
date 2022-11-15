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
        public double getMiddleBP(List<double> measurement)
        {
            return 0;
        }
        public double getSysBP(List<double> measurement)
        {
            return 0;
        }
        public double getDiaBP(List<double> measurement)
        {
            return 0;
        }
    }
}
