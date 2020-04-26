using GazePointView.ViewModel;
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

namespace GazePointView.View
{
    /// <summary>
    /// Interaction logic for Question1.xaml
    /// </summary>
    public partial class Question1 : UserControl
    {
        public Question1()
        {
            InitializeComponent();
            DataContext = new Question1ViewModel();

            Point locationFromScreen = this.prvoPitanje.TranslatePoint(new Point(0, 0), p1);


            // Transform screen point to WPF device independent point
         }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Point locationFromScreen = this.prvoPitanje.TranslatePoint(new Point(0, 0), p1);
            MainWindow.Position.Execute(Tuple.Create(locationFromScreen, p1));
        }
    }
}
