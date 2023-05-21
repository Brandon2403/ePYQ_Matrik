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
            RegisterCommand = new Command(OnRegister);
        }

        public ICommand RegisterCommand { get; private set; }

        private void OnRegister()
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

            // Navigate back to the login page
           
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginUI());
        }
    }  
}

