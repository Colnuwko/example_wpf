using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Security.Policy;

namespace MVVM
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Calculate my_class;

        // команда добавления нового объекта
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                     
                      my_class.set_result();
                  }));
            }
        }

        public Calculate SelectedPhone
        {
            get { return my_class; }
            set
            {
                my_class = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public ApplicationViewModel()
        {

            my_class = new Calculate { };    
           
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}