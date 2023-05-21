using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;


namespace ePYQ_Matrik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterNewUserPage : ContentPage
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public RegisterNewUserPage()
        {
            InitializeComponent();
            //RegisterCommand = new Command(OnRegister);
        }

        public ICommand RegisterCommand { get; private set; }

        /*private void OnRegister()
        {
            // Perform registration logic here
            // Create a new registered account
            Model.RegisteredAccount newAccount = new Model.RegisteredAccount
            {
                Username = Username,
                Password = Password
            };

            // Store the new account in the RegisteredAccount model
            Model.RegisteredAccount.AddRegisteredAccount(newAccount);
        }*/

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Perform registration logic here
            // Create a new registered account
            Model.RegisteredAccount newAccount = new Model.RegisteredAccount
            {
                Username = Username,
                Password = Password
            };

            // Store the new account in the RegisteredAccount model
            Model.RegisteredAccount.AddRegisteredAccount(newAccount);

            await DisplayAlert("Account", "Account has been creatted.", "OK");
            await Navigation.PushAsync(new LoginUI());
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            // Navigate back to the login page
            await Navigation.PushAsync(new LoginUI());
        }
    }  
}

