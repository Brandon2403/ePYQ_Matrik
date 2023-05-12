using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ePYQ_Matrik.ViewModel
{
    public class MyItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string PaperUrl { get; set; }
    }

    public class ListVM : INotifyPropertyChanged
    {

        public View Content { get; set; }

        public ListVM()
        {

            // Initialize your collection of items
            MyItems = new ObservableCollection<MyItem>
            {
                new MyItem
                {
                    Title = "Chemistry Trial Paper 2020",
                    Description = "Kolej Matrikulasi Perak",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/PDF_file_icon.svg/833px-PDF_file_icon.svg.png",
                    PaperUrl = "https://www.example.com/file.pdf"
                },
                new MyItem
                {
                    Title = "Physics Trial Paper 2022",
                    Description = "Kolej Matrikulasi Labuan",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/PDF_file_icon.svg/833px-PDF_file_icon.svg.png",
                    PaperUrl = "https://www.example.com/file.pdf"
                },
                  new MyItem
                {
                    Title = "Physics Trial Paper 2022",
                    Description = "Kolej Matrikulasi Labuan",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/PDF_file_icon.svg/833px-PDF_file_icon.svg.png",
                    PaperUrl = "https://www.example.com/file.pdf"
                },
                       new MyItem
                {
                    Title = "Physics Trial Paper 2022",
                    Description = "Kolej Matrikulasi Labuan",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/PDF_file_icon.svg/833px-PDF_file_icon.svg.png",
                    PaperUrl = "https://www.example.com/file.pdf"
                },
                            new MyItem
                {
                    Title = "Physics Trial Paper 2022",
                    Description = "Kolej Matrikulasi Labuan",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/PDF_file_icon.svg/833px-PDF_file_icon.svg.png",
                    PaperUrl = "https://www.example.com/file.pdf"
                },
             
                  
                // Add more items as needed
            };
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<MyItem> _myItems;
        public ObservableCollection<MyItem> MyItems
        {
            get { return _myItems; }
            set
            {
                _myItems = value;
                OnPropertyChanged(nameof(MyItems));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}