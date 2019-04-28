using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public class MainPageVM
    {
        private AFlightGearInfoModel infoModel;
        private ApplicationSettingsModel settingsModel;
        

        public MainPageVM(AFlightGearInfoModel infoM, ApplicationSettingsModel settingsM)
        {
            this.infoModel = infoM;
            this.settingsModel = settingsM;
        }

        private void Connect()
        {
            infoModel.Connect(IPAddress.Parse(this.settingsModel.FlightServerIP), this.settingsModel.FlightInfoPort);
        }
        private void Settings()
        {
            SettingsWindow settingW = new SettingsWindow(); 
            SettingVM vm = new SettingVM(this.settingsModel);

            settingW.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(settingW.Close);
            settingW.Show();
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
