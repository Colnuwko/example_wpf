using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace MVVM
{

    public class Calculate : INotifyPropertyChanged
    {

        private int first_num;
        private int second_num;
        private int total_num;
        private string time;
        

        public Calculate(int first_num, int second_num, int total_num)
        {
            this.first_num = first_num;
            this.second_num = second_num;
            this.total_num = total_num;
            this.time = DateTime.Now.ToString();
        }
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

        public string Time { get { return time;  } }
        public void set_result() {
            total_num = first_num + second_num;
            time = DateTime.Now.ToString();
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