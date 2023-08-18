using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperApp_MAUI.Models
{
    public class ToDo : INotifyPropertyChanged
    {
        int id;
        public int Id
        {
            get => id;
            set
            {
                if (id == value) return;

                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }

        string todoname;
        public string ToDoName
        {
            get => todoname;
            set
            {
                if (todoname == value) return;

                todoname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ToDoName)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
