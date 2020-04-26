﻿using System;
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
using GazePointClient.ViewModels;

namespace GazePointClient.Views
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
        }

        
    }
}
