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
using Ticket_to_ride.Model;
using Ticket_to_ride.ViewModel;

namespace Ticket_to_ride.View
{
    /// <summary>
    /// Logique d'interaction pour GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        public GameView()
        {
            InitializeComponent();
        }

        public void LineClicked(object sender, MouseEventArgs e)
        {
            Line line = (Line)sender;
            List<City> cities = (List<City>)line.Tag;
            GameViewModel gameVM = (GameViewModel)DataContext;
            gameVM.SelectConnection(cities[0], cities[1]);
        }
    }
}
