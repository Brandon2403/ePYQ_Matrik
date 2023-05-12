using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;
using ePYQ_Matrik;
namespace ePYQ_Matrik
{

    // Define a class for the user login table
    public class userLogin : INotifyPropertyChanged
    {
        public int _userid;
        public string _username;
        public string _email;
        public string _password;

        public userLogin()
        {
        }

        public userLogin(string databasePath)
        {
            DatabasePath = databasePath;
        }

        [PrimaryKey, AutoIncrement]
        public int userid
        {
            get { return _userid; }
            set
            {
                _userid = value;
                OnPropertyChanged(nameof(userid));
            }
        }

        public string username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(username));
            }
        }

        public string email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(email));
            }
        }

        public string password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(password));
            }
        }

        public string DatabasePath { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        internal static object Table<T>()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void InsertuserLogin(object user)
        {
            throw new NotImplementedException();
        }
    }
}