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
    public class UserProfileVM : INotifyPropertyChanged
    {
        public UserProfileVM()
        {
            // Initialize any properties or fields that need to be set here.
        }

        public class User
        {
            public string Name { get; set; }
            public string ProfilePictureUrl { get; set; }
            public string Downloads { get; set; }

        }

        public View Content { get; set; }

        public UserProfileVM(User user)
        {
            // Create a new ScrollView and add the grid to it
            var scrollView = new ScrollView();

            // Create a new StackLayout for the page content
            var stackLayout = new StackLayout
            {
                Padding = new Thickness(10),
                Spacing = 10,
            };

            // Create a new Frame for the user profile picture
            var profilePictureFrame = new Frame
            {
                CornerRadius = 50,
                HeightRequest = 100,
                WidthRequest = 100,
                BackgroundColor = Color.Gray,
                HasShadow = false,
            };

            // Add the user profile picture to the Frame
            var profilePicture = new Image
            {
                Source = user.ProfilePictureUrl,
                Aspect = Aspect.AspectFill,
            };
            profilePictureFrame.Content = profilePicture;

            // Add the user name to the StackLayout
            var nameLabel = new Label
            {
                Text = user.Name,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            stackLayout.Children.Add(nameLabel);

            // Add the profile picture Frame to the StackLayout
            stackLayout.Children.Add(profilePictureFrame);

            // Add the recent downloads header to the StackLayout
            var recentDownloadsHeaderLabel = new Label
            {
                Text = "Recent Downloads",
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
            };
            stackLayout.Children.Add(recentDownloadsHeaderLabel);
        }

            // Get the list of recent downloads for the user
           /*var recentDownloads = user.Downloads.OrderByDescending(d => d.DownloadDate).Take(10);

            // Create a new ListView for the recent downloads
            var recentDownloadsListView = new ListView
            {
                ItemsSource = recentDownloads,
                ItemTemplate = new DataTemplate(() =>
                {
                    var downloadCell = new ImageCell();
                    downloadCell.SetBinding(ImageCell.TextProperty, "Title");
                    downloadCell.SetBinding(ImageCell.DetailProperty, "DownloadDate");
                    downloadCell.SetBinding(ImageCell.ImageSourceProperty, "ImageUrl");
                    return downloadCell;
                }),
            };
            stackLayout.Children.Add(recentDownloadsListView);

            // Set the content of the view model to the StackLayout inside the ScrollView
            scrollView.Content = stackLayout;
            Content = scrollView;
        }*/

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
