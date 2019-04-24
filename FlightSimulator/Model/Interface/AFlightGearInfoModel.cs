using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using FlightSimulator.ViewModels;

namespace FlightSimulator.Model.Interface
{
    public abstract class AFlightGearInfoModel : BaseNotify
    {

        private readonly object syncLock = new object();

        private double lon;
        private double lat;

        public double Lon
        {
            get
            {
                lock (syncLock)
                {
                    return lon;
                }
            }
            set
            {
                lock (syncLock)
                {
                    lon = value;
                    NotifyPropertyChanged("Lon");
                }

            }
        }
        public double Lat
        {
            get
            {
                lock (syncLock)
                {
                    return lat;
                }
            }
            set
            {
                lock (syncLock)
                {
                    lat = value;
                    NotifyPropertyChanged("Lat");
                }

            }
        }        

        public abstract void Connect(IPAddress ip, int port);

    }
}
