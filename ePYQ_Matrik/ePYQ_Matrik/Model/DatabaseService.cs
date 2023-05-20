using System.Collections.Generic;
using System.ComponentModel;
using SQLite;

namespace ePYQ_Matrik
{
    public class DatabaseService
    {
        private SQLiteConnection connection;

        public DatabaseService(string databasePath)
        {
            connection = new SQLiteConnection(databasePath);
            connection.CreateTable<UserLogin>();
        }

        public void InsertUserLogin(UserLogin user)
        {
            connection.Insert(user);
        }

        public List<UserLogin> GetAllUserLogins()
        {
            return connection.Table<UserLogin>().ToList();
        }
    }

    public class UserLogin : INotifyPropertyChanged
    {
        private int _userId;
        private string _username;
        private string _email;
        private string _password;

        [PrimaryKey, AutoIncrement]
        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
