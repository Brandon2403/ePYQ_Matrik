using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ePYQ_Matrik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginUI : ContentPage
    {
        public LoginUI()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.Text == "Login")
            {
                // TODO: Add code for user to login from using database

                if (UsernameEntry.Text == "admin" && PasswordEntry.Text == "123")
                {
                    Navigation.PushAsync(new MainPage());
                }
                else
                {
                    DisplayAlert("Opps!", "Username or Password is incorrect", "Ok");
                }
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterNewUserPage());
        }

    }

}