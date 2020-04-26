using GalaSoft.MvvmLight.Command;
using GazePointView.Model;
using GazePointView.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GazePointView.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<UserControl> userControls = new List<UserControl>() { new Question1(), new Question2(), new Question3(), new Question4(), new Question5() };
        private UserControl selectedControl;
        public  int i = 0;
        public  int ans = -1;
        public UserControl SelectedControl
        {
            get
            {
                return selectedControl;
            }
            set
            {
                selectedControl = value;
                RaisePropertyChanged("SelectedControl");
            }
        }

        

        public MainWindowViewModel()
        {
            
            
            GazePointClientProxy.StartRecording(1);
            
            NextQuestionCommand = new RelayCommand(OnNextQuestion);
            ConfirmAnswer = new RelayCommand<int>(OnConfirmAnswer);
            SelectedControl = userControls[i];
        }

        public RelayCommand NextQuestionCommand { get; set; }
        public static RelayCommand<int> ConfirmAnswer { get; set; }
       


       
       
        public void OnConfirmAnswer(int answer)
        {
            ans = answer;
        }
        public void OnNextQuestion()
        {
            if(i < userControls.Count() - 1){
                SelectedControl = userControls[(i = (++i))];
                GazePointClientProxy.ChangeQuestion(ans, i);
            }
            else
            {
                SelectedControl = new End();
                GazePointClientProxy.StopRecording(ans);
            }
            
        }
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
