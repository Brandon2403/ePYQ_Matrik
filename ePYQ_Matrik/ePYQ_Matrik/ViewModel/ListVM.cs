using System.Collections.ObjectModel;
using System.ComponentModel;
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
                    Title = "Biology",
                    Description = "Past Year Question",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/PDF_file_icon.svg/833px-PDF_file_icon.svg.png",
                    PaperUrl = "https://drive.google.com/drive/folders/10NTw_hz73klrdORC9uYyJewv9tqoeRfL?usp=sharing"
                },
                new MyItem
                {
                    Title = "Physics",
                    Description = "Past Year Question",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/PDF_file_icon.svg/833px-PDF_file_icon.svg.png",
                    PaperUrl = "https://drive.google.com/drive/folders/1WPSFpRFIo6WKWcISpytErcVDxeiaXdIU?usp=sharing"
                },
                new MyItem
                {
                    Title = "Chemistry",
                    Description = "Past Year Question",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/PDF_file_icon.svg/833px-PDF_file_icon.svg.png",
                    PaperUrl = "https://drive.google.com/drive/folders/1B41i-G2o4180EX3FKGb9F0ljgmVa_qhV?usp=sharing"
                },
                new MyItem
                {
                    Title = "Math",
                    Description = "Past Year Question",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/PDF_file_icon.svg/833px-PDF_file_icon.svg.png",
                    PaperUrl = "https://drive.google.com/drive/folders/1nzBm3ZnGNug4s8ClIMLdJFGz3xrmAMjQ?usp=sharing"
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