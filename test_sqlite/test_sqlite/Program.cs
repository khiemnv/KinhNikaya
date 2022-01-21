using System;
using System.Data.SQLite;

namespace test_sqlite
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\temp\until\KinhNikaya\test_sqlite\test.db";
            SQLiteConnection.CreateFile(path);
            SQLiteConnection cnn = new SQLiteConnection("Data Source=" + path + ";Version=3;");
            cnn.Open();

            string[] sqls = new string[] {
                        "CREATE TABLE keys("
                            + " ID INTEGER PRIMARY KEY AUTOINCREMENT,"
                            + " key TEXT"
                            + ");",
                        "CREATE TABLE words("
                            + " ID INTEGER PRIMARY KEY AUTOINCREMENT,"
                            + " keyId INT,"
                            + " titleId INT,"
                            + " paragraphId INT,"
                            + " pos INT,"
                            + " word TEXT"
                            + ");",
                        "CREATE INDEX wordsKeyId ON words(keyId);" };

            foreach (var sql in sqls)
            {
                SQLiteCommand command = new SQLiteCommand(sql, cnn);
                var n = command.ExecuteNonQuery();
                command.Dispose();
            }

            cnn.Close();
            cnn.Dispose();
        }
    }
}
