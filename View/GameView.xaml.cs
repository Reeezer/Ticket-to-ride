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
            //List<UIElement> lines = new List<UIElement>();
            //for (int i = 0; i < ConnectionsLines.Items.Count; i++)
            //{
            //    ContentPresenter uiElement = (ContentPresenter)ConnectionsLines.ItemContainerGenerator.ContainerFromIndex(i);
            //    Line line = uiElement.ContentTemplate.
            //    uiElement.Opacity = 0.1;
            //}

            Line line = sender as Line;
            List<City> cities = line.Tag as List<City>;
            GameViewModel gameVM = DataContext as GameViewModel;

            gameVM.SelectConnection(cities[0], cities[1], line);
        }

        public void ShownCardClicked(object sender, MouseEventArgs e)
        {
            Image image = sender as Image;
            int cardId = (int)image.Tag;
            GameViewModel gameVM = DataContext as GameViewModel;

            gameVM.TakeCardFromStack(cardId);
        }

        public void HandCardClicked(object sender, MouseEventArgs e)
        {
            Image image = sender as Image;
            int cardId = (int)image.Tag;
            GameViewModel gameVM = DataContext as GameViewModel;

            gameVM.HandCardSelect(cardId, image);
        }
    }
}
