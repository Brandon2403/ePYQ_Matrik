using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ePYQ_Matrik.Services;
using System.Collections.Generic;
using SQLite;
using ePYQ_Matrik;

namespace ePYQ_Matrik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginUI : ContentPage
    {
        public LoginUI()
        {
            InitializeComponent();
            BindingContext = new { UserLogin = new userLogin() };
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
                    var user = userLogin.Table<userLogin>().FirstOrDefault(u => u.username == UserLogin.username && u.password == UserLogin.password);
                    if (UsernameEntry.Text == user.username && PasswordEntry.Text == user.password)

                    {
                        if (RememberMe)
                        {
                            // Save the user's credentials to the database
                            var user1 = new userLogin
                            {
                                username = UsernameEntry.Text,
                                password = PasswordEntry.Text
                            };

                            string DatabasePath = null;
                            var database = new userLogin(DatabasePath);
                            database.InsertuserLogin(user1);
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


        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Check if the user's credentials were previously saved
            string savedUsername = Preferences.Get("Username", null);
            string savedPassword = Preferences.Get("Password", null);

            if (savedUsername != null && savedPassword != null)
            {
                UsernameEntry.Text = savedUsername;
                PasswordEntry.Text = savedPassword;
                RememberMe = true;
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