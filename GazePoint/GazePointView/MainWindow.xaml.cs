using GalaSoft.MvvmLight.Command;
using GazePointView.View;
using GazePointView.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace GazePointView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            Position = new RelayCommand<Tuple<Point, Question1>>(OnPosition);
        }

        StringBuilder b = new StringBuilder();
        static int i = 0;
        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point v = e.GetPosition(main);
            Console.WriteLine(Math.Round(v.X / 1920, 5)+ " " + Math.Round(v.Y / 1080, 5));
            b.Append(Math.Round(v.X / 1920, 5) + "," + Math.Round(v.Y / 1080, 5)+"\n");
            i++;
            if (i % 4 == 0)
                b.Append("\n");
            
        }

        public  void OnPosition(Tuple< Point ,Question1 > p)
        {
            Point pp =  p.Item2.TranslatePoint(p.Item1, main);
            double x = pp.X / 1920;
            double y = pp.Y / 1080;
        }
        public static RelayCommand<Tuple<Point, Question1>> Position { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Model.GazePointClientProxy.StartRecording(1);
            using (StreamWriter sw = File.CreateText("AOI.csv"))
            {
                sw.Write(b);
            }
        }
    }
}
