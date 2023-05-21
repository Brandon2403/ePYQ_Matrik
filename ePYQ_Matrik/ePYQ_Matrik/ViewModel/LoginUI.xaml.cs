using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;
using ePYQ_Matrik.Model;
using ePYQ_Matrik.ViewModel;


namespace ePYQ_Matrik
{
    public partial class LoginUI : ContentPage
    {
        public LoginUI()
        {
            InitializeComponent();
            LoginCommand = new Command(Login);
            RegisterCommand = new Command(Register);
        }


        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterNewUserPage());
        }
    }
}