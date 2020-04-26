using GalaSoft.MvvmLight.Command;
using GazePointClient.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GazePointClient.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<UserControl> userControls = new List<UserControl>() { new Question1(), new Question2() ,new Question3(),new Question4(),new Question5()};
        private UserControl selectedControl;
        public UserControl SelectedControl
        {
            get {
                return selectedControl;
            }
            set {
                selectedControl = value;
                RaisePropertyChanged("SelectedControl");
            }
        }

        int i = 0;

        public MainWindowViewModel()
        {
            NextQuestionCommand = new RelayCommand(OnNextQuestion);
            SelectedControl = userControls[i];
        }

        public RelayCommand NextQuestionCommand { get; set; }

        public void OnNextQuestion()
        {
            SelectedControl = (i < userControls.Count()-1)?userControls[(i =(++i))]:  new End();
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
