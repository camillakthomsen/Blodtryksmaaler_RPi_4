using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_RPi.Interfaces
{
    public interface IReceviesBloodPressureMeasurement
    {
        List<double> MeasureBP();
    }
}
