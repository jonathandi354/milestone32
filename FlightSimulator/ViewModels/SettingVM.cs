using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class SettingVM
    {
        private string ip;
        private string infoPort;
        private string commandPort;

        public Action CloseAction { get; set; }

        private ApplicationSettingsModel settingModel;

        public string IPSetting
        {
            get
            {
                return ip;
            }
            set
            {
                ip = value;

            }
        }

        public string InfoPortSetting
        {
            get
            {
                return infoPort;
            }
            set
            {
                infoPort = value;

            }
        }

        public string CommandPortSetting
        {
            get
            {
                return commandPort;
            }
            set
            {
                commandPort = value;

            }
        }

        public void initiateSettingModel()
        {
            this.settingModel = new ApplicationSettingsModel();
        }

        private void SetData()
        {
            if (settingModel == null)
            {
                initiateSettingModel();
            }
            this.settingModel.FlightServerIP = this.IPSetting;
            this.settingModel.FlightInfoPort = Int32.Parse(this.InfoPortSetting);
            this.settingModel.FlightCommandPort = Int32.Parse(this.CommandPortSetting);
            this.settingModel.SaveSettings();

        }

        private ICommand cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return cancelCommand ?? (cancelCommand =
                new CommandHandler(() => CancelClick()));
            }
        }
        private void CancelClick()
        {
            CloseAction();
        }

        private ICommand okCommand;
        public ICommand OkCommand
        {
            get
            {
                return okCommand ?? (okCommand =
                new CommandHandler(() => OkClick()));
            }
        }
        private void OkClick()
        {
            SetData();
        }

    }
}
