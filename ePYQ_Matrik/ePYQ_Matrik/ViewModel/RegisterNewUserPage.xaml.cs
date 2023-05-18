using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ePYQ_Matrik.ViewModel;
using ePYQ_Matrik.Model;

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
            var newUser = new userLogin
            {
                username = UsernameEntry.Text,
                password = PasswordEntry.Text
            };

            // Create an instance of DatabaseService
            var databaseService = new DatabaseService();

            // Insert the new user into the database using the instance
            databaseService.InsertuserLogin(newUser);

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

                if (googleUser != null)
                {
                    var databaseService = new DatabaseService(); // Create an instance of DatabaseService

                    // Check if the user already exists in the database using their email or any other unique identifier
                    var existingUser = databaseService.GetUserByEmail(googleUser.Email);

                    if (existingUser != null)
                    {
                        // User exists, perform sign-in
                        await DisplayAlert("Success", $"Welcome back, {existingUser.username}!", "OK");
                        await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        // User does not exist, create a new account
                        var newUser = new userLogin
                        {
                            username = googleUser.Name,
                            email = googleUser.Email,
                            // Set a default password or generate a random one
                            password = GenerateRandomPassword()
                        };

                        // Insert the new user into the database
                        databaseService.InsertuserLogin(newUser);

                        await DisplayAlert("Success", $"Welcome, {newUser.username}!", "OK");
                        await Navigation.PushAsync(new MainPage());
                    }
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
        private string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var password = new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
            return password;
        }
    }
}
