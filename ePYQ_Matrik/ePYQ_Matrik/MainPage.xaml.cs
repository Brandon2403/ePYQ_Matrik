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

            // Create an instance of the ListVM class and pass the MyGrid instance to its constructor
            var listVM = new ListVM(MyGrid);

            var viewModel = new ListVM(MyGrid);
            Content = viewModel.Content;


            // Set the binding context to the ListVM instance
            BindingContext = listVM;
        }
    }
}
