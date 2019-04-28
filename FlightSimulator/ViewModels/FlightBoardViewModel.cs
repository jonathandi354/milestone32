using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {

        private double lon;
        private double lat;

        public double Lon
        {
            get
            {
                return lon;
            }
            set
            {
                lon = value;
                NotifyPropertyChanged("Lon");

            }
        }
        public double Lat
        {
            get { return lat; }
            set
            {
                lat = value;
                NotifyPropertyChanged("Lat");
            }
        }

        private AFlightGearInfoModel model;

        public FlightBoardViewModel(AFlightGearInfoModel m)
        {
            this.model = m;
            model.PropertyChanged += EventHandler;
        }


        private void EventHandler(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Lon"))
            {
                if (this.model.Lon != this.Lon)
                {
                    this.Lon = this.model.Lon;

                }

            }
            if (e.PropertyName.Equals("Lat"))
            {
                if (this.model.Lat != this.Lat)
                {
                    this.Lat = this.model.Lat;

                }
            }
        } 

        public void ConnectModel(IPAddress ip, int port)
        {
            this.model.Connect(ip, port);
        }

    }
}
