using System;
using System.Threading.Tasks;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Xamarin.Essentials;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Auth.OAuth2.Web;
using Google.Apis.Util.Store;

namespace ePYQ_Matrik.ViewModel
{
    public class GoogleAuthenticationService
    {
        private static GoogleAuthenticationService instance;

        private GoogleAuthenticationService()
        {
        }

        public static GoogleAuthenticationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GoogleAuthenticationService();
                }
                return instance;
            }
        }

        public async Task<GoogleUser> LoginAsync()
        {
            try
            {
                // Obtain the client ID from the Google API project
                var clientId = "YOUR_CLIENT_ID_HERE";

                // Request a Google Sign-In token
                var initializer = new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = new ClientSecrets
                    {
                        ClientId = clientId,
                        ClientSecret = "YOUR_CLIENT_SECRET_HERE"
                    },
                    Scopes = new[] { "profile", "email" },
                    DataStore = new FileDataStore("Google.Apis.Auth")
                };

                var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    initializer,
                    new[] { "profile", "email" },
                    "user",
                    System.Threading.CancellationToken.None);

                // Verify the token and obtain user information
                var payload = await GoogleJsonWebSignature.ValidateAsync(credential.Token.AccessToken);
                var googleUser = new GoogleUser
                {
                    Id = payload.Subject,
                    Email = payload.Email,
                    Name = payload.Name,
                    PictureUrl = payload.Picture,
                    AccessToken = credential.Token.AccessToken,
                    IdToken = credential.Token.IdToken
                };

                return googleUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to sign in with Google.", ex);
            }
        }

    }

}

