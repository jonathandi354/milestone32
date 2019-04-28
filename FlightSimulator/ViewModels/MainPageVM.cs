using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class MainPageVM
    {
        private void Connect()
        {

        }
        private void Settings()
        {

        }
        private ICommand _connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand =
                    new CommandHandler(() => Connect()));
            }

        }
        private ICommand _settingsCommand;
        public ICommand SettingsCommand
        {
            get
            {
                return _settingsCommand ?? (_settingsCommand =
                    new CommandHandler(() => Settings()));
            }

        }
    }
}
