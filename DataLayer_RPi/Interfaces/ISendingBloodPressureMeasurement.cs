using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaspberryPiNetCore.ADC;

namespace DataLayer_RPi.Interfaces
{
    public interface ISendingBloodPressureMeasurement
    {
        
        void SendToPC(List<double> measurement);
    }
}
