using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ePYQ_Matrik.Model;
using ePYQ_Matrik.ViewModel;
using System.Windows.Input;
using System;

namespace ePYQ_Matrik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginUI : ContentPage
    {
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public ICommand LoginCommand { get; private set; }
        public ICommand RegisterCommand { get; private set; }

        private void Register()
        {
            Application.Current.MainPage = new RegisterNewUserPage();
        }

        private void Login()
        {
            RegisteredAccount account = RegisteredAccount.GetRegisteredAccount(Username);

            if (account != null && account.Password == Password)
            {
                Application.Current.MainPage = new MainPage();
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "Invalid username or password.", "OK");
            }
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            RegisteredAccount account = RegisteredAccount.GetRegisteredAccount(Username);

            if (account != null && account.Password == Password)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new MainPage()); // Navigates to the MainPage upon successful login
            }
            else
            {
                await DisplayAlert("Error", "Invalid username or password.", "OK"); // Displays an alert for invalid credentials
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterNewUserPage());
        }

    }
}
