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

            //DrawRectangle(10.0, 10.0, -10.0, -10.0);
        }

        // https://stackoverflow.com/questions/7854043/drawing-rectangle-between-two-points-with-arbitrary-width
        private void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            Polyline polyline = new Polyline();
            polyline.Points.Add(new Point(x1, y1));
            polyline.Points.Add(new Point(x2, y2));
            polyline.Stroke = Brushes.Blue;
            polyline.StrokeThickness = 10.0;

            //CanvasConnections.Children.Add(polyline);
        }
    }
}
