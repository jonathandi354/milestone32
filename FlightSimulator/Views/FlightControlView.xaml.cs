using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlightSimulator.ViewModels;
using FlightSimulator.Model;
namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for FlightControlView.xaml
    /// </summary>
    public partial class FlightControlView : UserControl
    {
        FlightViewModel vm;
        public FlightControlView()
        {
            InitializeComponent();
            //vm = new FlightViewModel(flightModel);
            vm = new FlightViewModel(new FlightModel(new Client()));
            DataContext = vm;
            //hj
                
        
        }

        private void Clear(object sender, RoutedEventArgs args)
        {
            FlightCode.Clear();
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
            string data = FlightCode.Text;
            vm.connect("127.0.0.1", 5402);
            vm.write(data);
            //disconnect automatically


        }
       
    }
}
