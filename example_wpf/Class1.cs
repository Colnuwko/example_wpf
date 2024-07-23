using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM
{
    public class Calculate : INotifyPropertyChanged
    {
        private int first_num;
        private int second_num;
        private int total_num;

        public int First_num
        {
            get { return first_num; }
            set
            {
                first_num = value;
                OnPropertyChanged("First_num");
            }
        }
        public int Second_num
        {
            get { return second_num; }
            set
            {
                second_num = value;
                OnPropertyChanged("Second_num");
            }
        }
        public int Total_num
        {
            get { return total_num; }
            set { total_num = value; }
        }

        public void set_result() {
            total_num = first_num + second_num;
            OnPropertyChanged("Total_num");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}