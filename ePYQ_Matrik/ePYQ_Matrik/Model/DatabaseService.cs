using System.ComponentModel;
using SQLite;

namespace ePYQ_Matrik.Model
{
    public class userLogin : INotifyPropertyChanged
    {
        private int _userid;
        private string _username;
        private string _email;
        private string _password;

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DatabaseService
    {
        private SQLiteConnection connection;

        public DatabaseService(string databasePath = "C:\\Users\\User\\source\\repos\\ePYQ_Matrik\\ePYQ_Matrik\\ePYQ_Matrik\\Model\\mydatabase.db")
        {
            connection = new SQLiteConnection(databasePath);
            connection.CreateTable<userLogin>();
        }

        public void InsertuserLogin(userLogin user)
        {
            connection.Insert(user);
        }
    }
}
