using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazePointClient.ViewModels
{
    public class Question3ViewModel
    {

        public RelayCommand<object> AnswerCommand { get; set; }

        public Question3ViewModel()
        {
            //start ClientTCP
            AnswerCommand = new RelayCommand<object>(OnAnswer);
        }

        public void OnAnswer(object par)
        {
            int ans = int.Parse(par.ToString());
            //Stop ClientTCP
        }
    }
}
