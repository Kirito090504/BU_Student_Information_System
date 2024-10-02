using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace StudentInformationSheet
{
    internal class DatabaseHandler
    {
        private readonly string connection_string;

        /// <summary>
        /// Get a connection to the database.
        /// </summary>
        /// <param name="db_name">The name of the database to use. (Optional)</param>
        /// <param name="host">The host IP of the database server. (Optional)</param>
        /// <param name="port">The host port of the database server. (Optional)</param>
        /// <param name="username">The username to use. (Optional)</param>
        /// <param name="password">The password to use. (Optional)</param>
        public DatabaseHandler(
            string db_name = "bu_student_information_system",
            string host = "localhost",
            int port = 3006,
            string username = "root",
            string password = ""
        )
        {
            this.connection_string =
                $"server={host};port={port};uid={username};pwd={password};database={db_name}";
        }

        /// <summary>
        /// Acquire a new connection to the database.
        /// </summary>
        /// <returns>A new MySQL connection.</returns>
        private MySqlConnection GetNewConnection() => new MySqlConnection(connection_string);

        /// <summary>
        /// Attempt to login a user. If the user's credentials are correct, return the user's information.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserModel Login(string username, string password) { return new UserModel(); }
    }
}
