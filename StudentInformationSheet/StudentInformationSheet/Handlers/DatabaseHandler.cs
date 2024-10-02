﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using StudentInformationSheet.Models;
using StudentInformationSheet.Handlers;
using System.ComponentModel;

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
            int port = 3306,
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
        public MySqlConnection GetNewConnection() => new MySqlConnection(connection_string);

        /// <summary>
        /// Attempt to login a user. If the user's credentials are correct, return the user's information.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserModel Login(string username, string password) {
            password = PasswordHandler.SHA256(password);
            using (MySqlConnection connection = GetNewConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT user_id FROM users WHERE username = @username AND userpass = @userpass";
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@userpass", password);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.GetUser(reader.GetInt32("user_id"));
                        }
                    }
                }
            }

            return new UserModel();
        }

        /// <summary>
        /// Get a user by their user ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserModel GetUser(int id) {
            using (MySqlConnection connection = GetNewConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM users WHERE user_id = @user_id";
                    command.Parameters.AddWithValue("@user_id", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserModel
                            {
                                user_id = reader.GetInt32("user_id"),
                                username = reader.GetString("username"),
                                userpass = reader.GetString("userpass"),
                                privilege = reader.GetInt32("privilege"),
                                full_name = reader.GetString("full_name"),
                                photo = ImageHandler.DecodeImage(reader.GetString("photo")),
                            };
                        }
                    }
                }
            }
            return new UserModel();
        }

        /// <summary>
        /// Get a student by their student ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentModel GetStudent(int id) { return new StudentModel(); }

    }
}
