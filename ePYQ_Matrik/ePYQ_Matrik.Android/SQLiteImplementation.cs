using ePYQ_Matrik.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]

namespace ePYQ_Matrik.Droid
{
    public class SQLite_Android : ISQLite
    {
        public string GetDatabasePath(string filename)
        {
            // Implement the logic to retrieve the database path for Android
            // For example:
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string databasePath = System.IO.Path.Combine(documentsPath, filename);
            return databasePath;
        }
    }
}
