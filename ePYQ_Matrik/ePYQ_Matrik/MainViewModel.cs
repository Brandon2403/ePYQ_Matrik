using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ePYQ_Matrik
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Subjects> Subjects;
        public ObservableCollection<Subjects> subjects
        {
            get { return Subjects; }
            set { Subjects = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("subjects"));

                }
        }


        public MainViewModel()
        {
            subjects = new ObservableCollection<Subjects>();
        }

        private void addData()
        {
            subjects.Add(new Subjects
            {
                id = 0,
                subject = "Mathematics"
            });

            subjects.Add(new Subjects
            {
                id = 1,
                subject = "Biology"
            });

            subjects.Add(new Subjects
            {
                id = 2,
                subject = "Chemistry"
            });

            subjects.Add(new Subjects
            {
                id = 3,
                subject = "Physics"
            });
        }

    }
}
