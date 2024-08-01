using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;


namespace MVVM
{

    public class Calculate : INotifyPropertyChanged
    {

        private string first_num;
        private string second_num;
        private string total_num;
        private string time;
        private Regex regex;

        public Calculate(string first_num, string second_num, string total_num)
        {
            this.first_num = first_num;
            this.second_num = second_num;
            this.total_num = total_num;
            this.time = DateTime.Now.ToString();
            this.regex = new Regex(@"^\-?\d*\,?\d*$");
        }
        public string First_num
        {
            get { return first_num; }
            set
            {
                if(regex.IsMatch(value))
                { first_num = value; }
                OnPropertyChanged("First_num");
            }
        }
        public string Second_num
        {
            get { return second_num; }
            set
            {
                if (regex.IsMatch(value))
                { second_num = value; }
                OnPropertyChanged("Second_num");
            }
        }
        public string Total_num
        {
            get { return total_num; }
            set { total_num = value; }
        }

        public string Time { get { return time;  } }
        public void set_result() {
            if(first_num.Length ==0) { first_num = "0"; }
            if(second_num.Length ==0) {  second_num = "0"; }
            total_num = (Double.Parse(first_num) + Double.Parse(second_num)).ToString();
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