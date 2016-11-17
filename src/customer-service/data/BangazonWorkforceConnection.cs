using System;
using Microsoft.Data.Sqlite;

namespace customer_service.Data
{
    /**
     * Class: BangazonWorkforceConnection
     * Purpose: Connects App with Workforce DB allows for executing and reading commands
     * Author: Matt Hamil
     * Methods:
     *     
     *     void insert(string query) - This method allows for users to insert new information into workforce database
     *     void execute(string query, Action<SqliteDataReader> handler) - This method opens the database, executes a given command(handler) and then closes the connection
     */
    public class BangazonWorkforceConnection
    {
        private string _path = "Data Source=" + System.Environment.GetEnvironmentVariable("Bangazon_Workforce_Db");

        /**
         * Purpose: Inserts new information into the workforce database
         * Arguments:
         *     query - database query
         * Return:
         *     n/a 
         */
        public void insert(string query)
        {
            SqliteConnection dbcon = new SqliteConnection(_path);

            dbcon.Open();
            SqliteCommand dbcmd = dbcon.CreateCommand();

            dbcmd.CommandText = query;
            dbcmd.ExecuteNonQuery();

            // clean up
            dbcmd.Dispose();
            dbcon.Close();
        }
        /**
         * Purpose: Execute SQL statement
         * Arguments:
         *     query - workforce database query
         *     Action<SqliteDataReader> handler - callback function to be executed during connection
         * Return:
         *     n/a 
         */
        public void execute(string query, Action<SqliteDataReader> handler)
        {

            SqliteConnection dbcon = new SqliteConnection(_path);

            dbcon.Open();
            SqliteCommand dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = query;

            using (var reader = dbcmd.ExecuteReader())
            {
                handler(reader);
            }

            dbcmd.Dispose();
            dbcon.Close();
        }
    }
}
