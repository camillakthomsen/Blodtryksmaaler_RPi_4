using LogicLayer_RPi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer_RPi
{
    public class AlarmChecker:IAlarmChecker
    {
        public int checkAlarm(List<double> measurement)
        { 
            return 1;
        }
    }
}
