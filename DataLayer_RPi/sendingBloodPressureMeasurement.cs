using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_RPi
{
    public class sendingBloodPressureMeasurement
    {
        private static int receiverPortNo = 12000;
        private UdpClient udpClient = new UdpClient();
      
      
        public void SendToPC(List<double> measurement)
        {
            string message = convertListToString(measurement);
            //string message = " hej";

            byte[] packet = Encoding.ASCII.GetBytes(message);

            try
            {
                udpClient.Send(packet, packet.Length, IPAddress.Broadcast.ToString(), receiverPortNo);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private string convertListToString(List<double> measurement)
        {
            string s = "";
            foreach(double value in measurement)
            {
                s += Convert.ToString(value) + " ";
            }

            return s;
        }
    }
}
