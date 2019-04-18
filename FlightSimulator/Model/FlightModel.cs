using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.Interface;
namespace FlightSimulator.Model
{
    public class FlightModel 
    {
        private ITelnetClient telnet;
        //volatile bool stop;
        public FlightModel(ITelnetClient telnet)
        {
            this.telnet = telnet;
        }

       
        public double Aileron { get; set; }
        public double Elevator { get; set; }
        public bool IsManual { get; set; }
        public double Rudder { get; set; }
        
        public double Throttle { get; set; }
        public void connect(string ip, int port)
        {
            telnet.connect(ip, port);
        }
        public void disconnect()
        {
            //stop = true;
            telnet.disconnect();
        }
        public void write(string data)
        {
            telnet.write(data);
        }

    }
}
