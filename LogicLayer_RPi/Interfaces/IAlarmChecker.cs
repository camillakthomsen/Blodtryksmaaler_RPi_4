using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer_RPi.Interfaces
{
    public interface IAlarmChecker
    {
        int checkAlarm(List<double> measurement);
    }
}
