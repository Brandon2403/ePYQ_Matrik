using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ePYQ_Matrik.Services;

namespace ePYQ_Matrik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterNewUserPage : ContentPage
    {
        private bool isGoogleSignInInProgress;

        public RegisterNewUserPage()
        {
            InitializeComponent();

            isGoogleSignInInProgress = false;
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            // Perform validation on user input
            if (string.IsNullOrWhiteSpace(UsernameEntry.Text))
            {
                await DisplayAlert("Error", "Please enter a username.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                await DisplayAlert("Error", "Please enter a password.", "OK");
                return;
            }

            if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
            {
                await DisplayAlert("Error", "Passwords do not match.", "OK");
                return;
            }

            // TODO: Add code to register new user in database

            // Show success message and navigate to login page
            await DisplayAlert("Success", "Your account has been created.", "OK");
            await Navigation.PopAsync();
        }

        private async void GoogleSignInButton_Clicked(object sender, EventArgs e)
        {
            if (isGoogleSignInInProgress)
            {
                return;
            }

            isGoogleSignInInProgress = true;

            try
            {
                var googleUser = await GoogleAuthenticationService.Instance.LoginAsync();

                // TODO: Use the googleUser object to sign in the user or create a new account.

                // Example:
                if (googleUser != null)
                {
                    // Save user information to database or local storage
                    await DisplayAlert("Success", $"Welcome, {googleUser.Name}!", "OK");

                    // Redirect the user to the main page
                    await Navigation.PushAsync(new MainPage());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                isGoogleSignInInProgress = false;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginUI());
        }
    }
}
