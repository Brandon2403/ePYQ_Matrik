using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using ePYQ_Matrik.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ePYQ_Matrik
{
    public partial class MainPage : ContentPage
    {
        private ListVM listVM;

        public MainPage()
        {
            InitializeComponent();
            listVM = new ListVM(); //Instantiate ListVM

            // assigning the PaperUrl from the ListVM to a variable in the MainPage
            PaperUrl = listVM.MyItems[0].PaperUrl;

            BindingContext = listVM; // Set the binding context

        }

        private string _paperUrl;
        public string PaperUrl
        {
            get { return _paperUrl; }
            set
            {
                _paperUrl = value;
                OnPropertyChanged(nameof(PaperUrl));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class AdaptiveLabel : Label
        {
            public AdaptiveLabel()
            {
                double fontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label));
                double width = Application.Current.MainPage.Width;

                FontSize = Math.Min(fontSize, width / 20);
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var tappedItem = (sender as View)?.BindingContext as MyItem;
            if (tappedItem != null)
            {
                Uri uri = new Uri(tappedItem.PaperUrl);
                await Launcher.OpenAsync(uri);
            }
        }


        private void TabViewItem_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}
