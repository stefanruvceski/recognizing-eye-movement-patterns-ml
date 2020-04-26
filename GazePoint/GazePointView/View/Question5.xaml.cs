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
    /// Interaction logic for Question5.xaml
    /// </summary>
    public partial class Question5 : UserControl
    {
        public Question5()
        {
            InitializeComponent();
            DataContext = new Question5ViewModel();
        }
    }
}
