using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ePYQ_Matrik
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
         
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

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void TabViewItem_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}
