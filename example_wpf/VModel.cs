using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace MVVM
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Calculate my_class;
        private ObservableCollection<Calculate> my_calculations { get; set; }
        private Json my_json;

        // команда добавления нового объекта
        private RelayCommand addCommand;
        private RelayCommand addCalc;
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


        public RelayCommand AddCalc
        {
            get
            {
                return addCalc ??
                    (addCalc = new RelayCommand(obj =>
                    {
                        my_class.set_result();
                        my_json.AddCalculation(my_class.First_num, my_class.Second_num, my_class.Total_num);
                        my_calculations = my_json.GetCalculations;
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

        public ObservableCollection<Calculate> Calculations
        {  get { return my_calculations; } }

        public Json Json { get { return my_json; } }
        public ApplicationViewModel()
        {

            my_class = new Calculate(0, 0, 0);
            my_json = new Json { };
            my_calculations = my_json.GetCalculations;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}