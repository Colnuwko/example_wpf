using System.ComponentModel;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.IO;
using System;

namespace MVVM 
{
    public class Json : INotifyPropertyChanged
    {
        private ObservableCollection<Calculate> calculations;

        public ObservableCollection<Calculate> GetCalculations { get { return calculations; } }

        public Json()
        {
            try
            {
                string str_from_json = File.ReadAllText(@"./save.json");
                calculations = JsonSerializer.Deserialize<ObservableCollection<Calculate>>(str_from_json);
            }
            catch (Exception ex) { 
                Console.WriteLine("Файл сохраненных данных пуст или не найден. История сохранений будет перезаписана");
                calculations = new ObservableCollection<Calculate>();
                FileStream createStream = File.Create(@"./save.json");
                createStream.Close();
            }

        }
        public void AddCalculation(int first_num, int second_num, int total_num)
        {
            if (first_num != 0 || second_num != 0)
            {
                calculations.Add(new Calculate(first_num, second_num, total_num));
                string ser_my_calculations = JsonSerializer.Serialize(calculations);
                File.WriteAllText(@"./save.json", ser_my_calculations);
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