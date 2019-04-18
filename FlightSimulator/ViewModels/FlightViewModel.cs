using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlightSimulator.Model;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class FlightViewModel : BaseNotify
    {
        private FlightModel _model;

        public FlightViewModel(FlightModel model)
        {
            _model = model;
        }

        public double Aileron
        {
            get
            {
                return _model.Aileron;
            }
            set
            {
                _model.Aileron = value;
                NotifyPropertyChanged("Aileron");
            }
        }
        public double Elevator
        {
            get
            {
                return _model.Elevator;
            }
            set
            {
                _model.Elevator = value;
                NotifyPropertyChanged("Elevator");
            }
        }
        public bool IsManual
        {
            get
            {
                return _model.IsManual;

            }
            set
            {
                _model.IsManual = value;
                NotifyPropertyChanged("IsManual");
            }
        }
        public double Rudder
        {
            get
            {
                return _model.Rudder;
            }
            set
            {
                _model.Rudder = value;
                NotifyPropertyChanged("Rudder");
                this.connect("127.0.0.1", 5402);
                write("set controls/flight/rudder "+value);
            }
        }
        public double Throttle
        {
            get
            {
                return _model.Throttle;
            }
            set
            {
                _model.Throttle = value;
                NotifyPropertyChanged("Throttle");
            }
        }
        public void connect(string ip, int port)
        {
            _model.connect(ip, port);   
        }
        public void write(string data)
        {
            _model.write(data);
        }
        public void disconnect()
        {
            _model.disconnect();
        }
        


    }
}
