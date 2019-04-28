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
            ITelnetClient commandModel = new Client();
            base.OnStartup(e);
            MainWindow main = new MainWindow();
            main.DataContext = new MainPageVM();
            main.Board.DataContext = new FlightBoardViewModel(infoModel);
            main.Control.DataContext = commandModel;
            main.Show();
        }
    }
}
