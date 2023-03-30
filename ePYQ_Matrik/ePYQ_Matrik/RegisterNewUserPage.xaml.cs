﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ePYQ_Matrik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterNewUserPage : ContentPage
    {
        public RegisterNewUserPage()
        {
            InitializeComponent();
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
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginUI());
        }
    }
}