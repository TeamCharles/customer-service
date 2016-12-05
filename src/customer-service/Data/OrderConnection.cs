using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace customer_service
{
    /**
     * Class: OrderConnection
     * Purpose: Connects App with Bangazon_Order DB allows for executing and reading commands
     * Author: Matt Kraatz
     * Methods:
     *     
     *     void insert(string query) - This method allows for users to insert new information into a SQLite database
     *     void execute(string query, Action<SqliteDataReader> handler) - This method opens the database, executes a given command(handler) and then closes the connection
     */
    public class OrderConnection
    {
        private string _path = "Data Source=" + System.Environment.GetEnvironmentVariable("Bangazon_Order_DB");

        /**
         * Purpose: Inserts new information into the datase
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
         *     query - database query
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
