﻿using GalaSoft.MvvmLight.Command;
using GazePointView.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazePointView.ViewModel
{
    public class Question4ViewModel
    {
        public RelayCommand<object> AnswerCommand { get; set; }

        public Question4ViewModel()
        {
            AnswerCommand = new RelayCommand<object>(OnAnswer);
        }

        public void OnAnswer(object par)
        {
            int ans = int.Parse(par.ToString());
            //Stop ClientTCP
            MainWindowViewModel.ConfirmAnswer.Execute(ans);

            Console.WriteLine("STOPIRANO. Odgovor " + ans);
        }
    }
}
