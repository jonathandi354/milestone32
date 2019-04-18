using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSimulator.Model.EventArgs
{
    public class VirtualJoystickEventArgs
    {
        //.EventArgs
        public double Aileron { get; set; }
        public double Elevator { get; set; }
        public bool IsManual { get; set; }
        public double Rudder { get; set; }
        public double Throttle { get; set; }


    }
}
