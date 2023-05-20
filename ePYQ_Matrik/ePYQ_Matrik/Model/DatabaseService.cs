using System;
using System.Collections.Generic;
using System.ComponentModel;
using SQLite;
using System.IO;
using System.Numerics;

namespace ePYQ_Matrik
{
    public class DatabaseService
    {
        private  SQLiteConnection connection;

        public DatabaseService(string databasePath)
        {
            connection = new SQLiteConnection(databasePath);
        }

        public void InsertUserLogin(userLogin user)
        {
            connection.Insert(user);
        }

        public List<userLogin> GetAllUserLogins()
        {
            return connection.Table<userLogin>().ToList();
        }
        public userLogin GetUserByEmail(string email)
        {
            return connection.Table<userLogin>().FirstOrDefault(u => u.Email == email);
        }
    }

    public class userLogin
    {
        [PrimaryKey, AutoIncrement]
        public int userID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        /*public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }*/
    }
}
