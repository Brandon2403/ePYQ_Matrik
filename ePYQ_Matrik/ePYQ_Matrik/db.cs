using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ePYQ_Matrik
{

    // Define a class for the user login table
    public class userLogin
    {
        [PrimaryKey, AutoIncrement]
        public int userid { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }

    // Define a class for the subject table
    public class subject
    {
        [PrimaryKey, AutoIncrement]
        public int subject_id { get; set; }
        public string subject_name { get; set; }
        public string subject_link { get; set; }

    }

    // Access the database
    public class MatrixDatabase
    {
        private SQLiteConnection database;

        public MatrixDatabase(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<userLogin>();
            database.CreateTable<subject>();
        }

        // Insert user info
        public void InsertuserLogin(userLogin login)
        {
            database.Insert(login);
        }

        // Insert a subject record
        public void Insertsubject(subject subject)
        {
            database.Insert(subject);
        }

        // Retrieve all userLogin
        public List<userLogin> GetAlluserLogin()
        {
            return database.Table<userLogin>().ToList();
        }

        // Retrieve all subject
        public List<subject> GetAllsubject()
        {
            return database.Table<subject>().ToList();
        }
    }

}