using System.Collections.Generic;

namespace ePYQ_Matrik.Model
{
    public class RegisteredAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }

        // Collection to store registered accounts
        private static List<RegisteredAccount> RegisteredAccounts { get; } = new List<RegisteredAccount>();

        // Method to retrieve a registered account based on username
        public static RegisteredAccount GetRegisteredAccount(string username)
        {
            return RegisteredAccounts.Find(account => account.Username == username);
        }

        // Method to add a new registered account
        public static void AddRegisteredAccount(RegisteredAccount account)
        {
            RegisteredAccounts.Add(account);
        }

        // Static constructor to initialize default registered accounts
        static RegisteredAccount()
        {
            // Create a default registered account
            RegisteredAccount defaultAccount = new RegisteredAccount
            {
                Username = "admin",
                Password = "admin"
            };

            // Add the default account to the registered accounts collection
            AddRegisteredAccount(defaultAccount);
        }
    }
}
