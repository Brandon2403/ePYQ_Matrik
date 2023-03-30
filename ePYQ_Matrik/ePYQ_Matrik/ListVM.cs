using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ePYQ_Matrik
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
        public ListVM()
        {
            // Initialize any properties or fields that need to be set here.
        }

        public View Content { get; set; }

        private readonly Grid _myGrid;

        public ListVM(Grid myGrid)
        {
            _myGrid = myGrid;

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

            // Create a new ScrollView and add the grid to it
            var scrollView = new ScrollView
            {
                Content = _myGrid,
            };

            // Set the content of the view model to the ScrollView
            Content = scrollView;

            AddItemsToGrid();

        }

        private void AddItemsToGrid()
        {
            // Get the list of items from the view model
            var items = MyItems;

            // Loop through each item and add it to the grid
            int row = 0;
            int col = 0;
            foreach (var item in items)
            {
                // Create a new view for the item
                var itemView = new Frame
                {
                    Padding = new Thickness(10),
                    BackgroundColor = ColorConverters.FromHex("#E5E1E7"),
                    CornerRadius = 20,
                    HasShadow = false,
                    VerticalOptions = LayoutOptions.EndAndExpand,

                    Content = new StackLayout
                    {
                        Children =
                        {
                            new Frame
                            {
                                CornerRadius = 20,
                                BackgroundColor = Color.Transparent,
                                HasShadow = false,
                                HeightRequest = 168,
                                WidthRequest = 160,
                                Content = new Image
                                {
                                    Source = item.ImageUrl,
                                    Aspect = Aspect.AspectFill,
                                    WidthRequest = 116,
                                    HeightRequest = 132,
                                    VerticalOptions = LayoutOptions.StartAndExpand,
                                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                                    Margin = 8,
                                }
                            },

                            new Label
                            {
                                Text = item.Title,
                                FontAttributes = FontAttributes.Bold,
                                FontSize = 14,
                                TextColor = Color.Black,
                                Margin = new Thickness(0),
                                Padding = new Thickness(0),
                                VerticalOptions = LayoutOptions.EndAndExpand,
                                HorizontalOptions = LayoutOptions.CenterAndExpand,
                                HorizontalTextAlignment = TextAlignment.Center,
                                VerticalTextAlignment = TextAlignment.Center,
                                LineHeight = 1.2,
                                GestureRecognizers =
                                    {
                                        new TapGestureRecognizer
                                        {
                                            Command = new Command(async () =>
                                            {
                                                // Implement the logic to open the PDF file here
                                                await Launcher.OpenAsync(new Uri(item.PaperUrl));
                                            })
                                        }
                                    }
                            },

                            new Label
                            {
                                Text = item.Description,
                                FontAttributes = FontAttributes.None,
                                FontSize = 10,
                                TextColor = Color.Black,
                                Margin = new Thickness(0),
                                Padding = new Thickness(0),
                                VerticalOptions = LayoutOptions.EndAndExpand,
                                HorizontalOptions = LayoutOptions.CenterAndExpand,
                                HorizontalTextAlignment = TextAlignment.Center,
                                VerticalTextAlignment = TextAlignment.Center,
                                LineHeight = 0.6,
                            }

                          }
                    }
                };

                // Set the height request of the Frame based on the content
                itemView.HeightRequest = itemView.Content.Measure(double.PositiveInfinity, double.PositiveInfinity).Request.Height + itemView.Padding.VerticalThickness;

                // Add the view to the grid at the current row and column
                _myGrid.Children.Add(itemView, col, row);

                // Increment the row and column counters
                col++;
                if (col == 2)
                {
                    col = 0;
                    row++;
                }
            }
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