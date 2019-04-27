using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlightSimulator.Model;
using System.Windows.Input;
using System.Windows.Media;

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
                writeOne("set controls/flight/aileron " + value, "127.0.0.1", 5402);
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
                writeOne("set controls/flight/elevator "+value, "127.0.0.1", 5402);
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
                writeOne("set controls/flight/rudder "+value, "127.0.0.1", 5402);

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
                writeOne("set /controls/engines/current-engine/throttle " + value, "127.0.0.1", 5402);
            }
        }
        /*public void connect(string ip, int port)
        {
            _model.connect(ip, port);   
        }*/
        public void write(string data, string ip, int port)
        {
            _model.write(data, ip, port);
        }
        /*public void disconnect()
        {
            _model.disconnect();
        }*/
        public void writeOne(string str, string ip, int port)
        {
            _model.writeOne(str, ip, port);
        }

        private string data;
        public string Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                Background = "Pink";
                //B = "Pink";
                //Background = new SolidColorBrush(Colors.PaleVioletRed);
                NotifyPropertyChanged("Data");
                //Background = "Pink";
                
            }
        }
        
        private ICommand _okCommand;
        public ICommand OkCommand
        {
            get
            {
                return _okCommand ?? (_okCommand =
                    new CommandHandler(() => Ok()));
            }

        }
        private void Ok()
        {
            
            write(data, "127.0.0.1", 5402);
            Background = "White";


        }

        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand =
                    new CommandHandler(() => Clear()));
            }

        }
        private void Clear()
        {
            Data = "";
            Background = "White";
        }
        
        private string backgroung;
        public string Background
        {
            get
            {
                return backgroung;
            }
            set
            {
                backgroung = value;
                NotifyPropertyChanged("Background");
            }
        }
        




    }
}
