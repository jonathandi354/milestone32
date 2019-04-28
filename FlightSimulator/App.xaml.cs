using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AFlightGearInfoModel infoModel = new InfoModel();
            FlightModel commandModel = new FlightModel(new Client());
            ApplicationSettingsModel settingM = new ApplicationSettingsModel();
            base.OnStartup(e);
            MainWindow main = new MainWindow();
            main.DataContext = new MainPageVM(infoModel, settingM);
            main.Board.InitiateVM(new FlightBoardViewModel(infoModel));
            main.Control.DataContext = new FlightViewModel(commandModel, settingM);
            main.Show();
        }
    }
}
