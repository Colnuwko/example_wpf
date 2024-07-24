using System.ComponentModel;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
namespace MVVM
{
    public class Json : INotifyPropertyChanged
    {
        private ObservableCollection<Calculate> calculations;

        public ObservableCollection<Calculate> GetCalculations { get { return calculations; } }

        public Json()
        {
            calculations = new ObservableCollection<Calculate> {
                new Calculate(1, 3, 1),
                new Calculate(1, 3, 4),
                new Calculate(1, 3, 5),
                new Calculate(1, 3, 5)
            };
            

        }
        public void AddCalculation(int first_num, int second_num, int total_num)
        {
            if (first_num != 0 || second_num != 0)
            {
                calculations.Add(new Calculate(first_num, second_num, total_num));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}