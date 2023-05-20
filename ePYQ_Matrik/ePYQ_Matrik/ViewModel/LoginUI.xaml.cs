using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using SQLite;
using ePYQ_Matrik.ViewModel;
using System.IO;

namespace ePYQ_Matrik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginUI : ContentPage
    {
        private DatabaseService databaseService; // Declare the databaseService variable
        public LoginUI()
        {
            InitializeComponent();
            string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mydatabase.db");
            databaseService = new DatabaseService(databasePath);


        }

        private bool rememberMe = false;

        public bool RememberMe
        {
            get { return rememberMe; }
            set { rememberMe = value; }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.Text == "Login")
            {
                if (GoogleSignInClicked)
                {
                    try
                    {
                        var googleUser = await GoogleAuthenticationService.Instance.LoginAsync();

                        // TODO: Use the googleUser object to sign in the user or create a new account.

                        // Example:
                        if (googleUser != null)
                        {
                            // Save user information to database or local storage
                            await DisplayAlert("Success", $"Welcome, {googleUser.Name}!", "OK");
                            await Navigation.PushAsync(new MainPage());
                        }
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Error", ex.Message, "OK");
                    }
                }
                else
                {

                    // TODO: Authenticate the user using your app's authentication system
                    // Example:

                    var login = new UserLogin();
                    if (UsernameEntry.Text == login.Username && PasswordEntry.Text == login.Password)
                    {
                        if (RememberMe)
                        {
                            // Save the user's credentials to the database
                            var user = new UserLogin
                            {
                                Username = UsernameEntry.Text,
                                Password = PasswordEntry.Text
                            };

                            databaseService.InsertUserLogin(user);
                        }

                        await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        await DisplayAlert("Oops!", "Username or Password is incorrect", "Ok");
                    }
                }
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            // Save the entered username and password when the view is closed
            if (RememberMe)
            {
                Preferences.Set("Username", UsernameEntry.Text);
                Preferences.Set("Password", PasswordEntry.Text);
            }
            else
            {
                Preferences.Remove("Username");
                Preferences.Remove("Password");
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterNewUserPage());
        }

        private bool GoogleSignInClicked = false;

        private async void OnGoogleSignInButtonClicked(object sender, EventArgs e)
        {
            GoogleSignInClicked = true;

            try
            {
                var googleUser = await GoogleAuthenticationService.Instance.LoginAsync();

                // TODO: Use the googleUser object to sign in the user or create a new account.

                // Example:
                if (googleUser != null)
                {
                    // Save user information to database or local storage
                    await DisplayAlert("Success", $"Welcome, {googleUser.Name}!", "OK");
                    await Navigation.PushAsync(new MainPage());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }

            GoogleSignInClicked = false;
        }
    }

}