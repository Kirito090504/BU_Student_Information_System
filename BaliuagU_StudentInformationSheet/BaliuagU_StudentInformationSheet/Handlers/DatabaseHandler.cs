#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaliuagU_StudentInformationSheet.Handlers;
using BaliuagU_StudentInformationSheet.Models;
using MySql.Data.MySqlClient;
using StudentInformationSheet.Models;

namespace BaliuagU_StudentInformationSheet
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
        /// <param name="username">The username of the user to log in as.</param>
        /// <param name="password">The password of the user to log in as.</param>
        /// <returns>Returns a UserModel object if the user exists and the credentials are correct. Otherwise, return null.</returns>
        public UserModel? Login(string username, string password)
        {
            password = PasswordHandler.SHA256(password);
            using (MySqlConnection connection = GetNewConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT user_id FROM users WHERE username = @username AND userpass = @userpass";
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@userpass", password);

                    using (MySqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                            return this.GetUser(reader.GetInt32("user_id"));
                }
            }

            return null;
        }

        /// <summary>
        /// Get a user by their user ID.
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <returns>Returns a UserModel object if the user with the specified ID exists. Otherwise, return null.</returns>
        public UserModel? GetUser(int id)
        {
            using (MySqlConnection connection = GetNewConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM users WHERE user_id = @user_id";
                    command.Parameters.AddWithValue("@user_id", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                            return new UserModel(
                                user_id: reader.GetInt32("user_id"),
                                username: reader.GetString("username"),
                                userpass: reader.GetString("userpass"),
                                privilege: (UserModel.Privilege)reader.GetInt32("privilege"),
                                full_name: reader.IsDBNull(reader.GetOrdinal("full_name"))
                                    ? null
                                    : reader.GetString("full_name")
                            );
                }
            }
            return null;
        }

        public void AddUser(UserModel user)
        {
            using (MySqlConnection connection = GetNewConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        "INSERT INTO "
                        + "users (username, userpass, privilege, full_name) "
                        + "VALUES (@username, @userpass, @privilege, @full_name)";
                    command.Parameters.AddWithValue("@username", user.username);
                    command.Parameters.AddWithValue(
                        "@userpass",
                        PasswordHandler.SHA256(user.userpass)
                    );
                    command.Parameters.AddWithValue("@privilege", (int)user.privilege);
                    command.Parameters.AddWithValue("@full_name", user.full_name);

                    if (command.ExecuteNonQuery() != 1)
                        throw new Exception("Failed to add user.");
                }
            }
        }

        public void UpdateUser(UserModel user)
        {
            using (MySqlConnection connection = GetNewConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        "UPDATE users SET username = @username, userpass = @userpass, "
                        + "privilege = @privilege, full_name = @full_name WHERE user_id = @user_id";
                    command.Parameters.AddWithValue("@username", user.username);
                    command.Parameters.AddWithValue(
                        "@userpass",
                        PasswordHandler.SHA256(user.userpass)
                    );
                    command.Parameters.AddWithValue("@privilege", (int)user.privilege);
                    command.Parameters.AddWithValue("@full_name", user.full_name);
                    command.Parameters.AddWithValue("@user_id", user.user_id);

                    if (command.ExecuteNonQuery() != 1)
                        throw new Exception("Failed to update user.");
                }
            }
        }

        public void DeleteUser(int user_id)
        {
            using (MySqlConnection connection = GetNewConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM users WHERE user_id = @user_id";
                    command.Parameters.AddWithValue("@user_id", user_id);

                    if (command.ExecuteNonQuery() != 1)
                        throw new Exception("Failed to delete user.");
                }
            }
        }

        /// <summary>
        /// Get all users in the database.
        /// </summary>
        /// <returns>A list of users in the database.</returns>
        public List<UserModel> GetUsers()
        {
            List<UserModel> users = new List<UserModel>();
            using (MySqlConnection connection = GetNewConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM users";
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(
                                new UserModel(
                                    user_id: reader.GetInt32("user_id"),
                                    username: reader.GetString("username"),
                                    userpass: reader.GetString("userpass"),
                                    privilege: (UserModel.Privilege)reader.GetInt32("privilege"),
                                    full_name: reader.IsDBNull(reader.GetOrdinal("full_name"))
                                        ? null
                                        : reader.GetString("full_name")
                                )
                            );
                        }
                    }
                }
            }
            return users;
        }

        public List<StudentModel> GetStudents()
        {
            List<StudentModel> users = new List<StudentModel>();
            using (MySqlConnection connection = GetNewConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM students";
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(
                                new StudentModel(
                                    student_number: reader.GetString("student_number"),
                                    name: new Models.StudentSubModels.StudentName(
                                        first: reader.GetString("name_first"),
                                        middle: reader.IsDBNull(reader.GetOrdinal("name_middle"))
                                            ? null
                                            : reader.GetString("name_middle"),
                                        last: reader.GetString("name_last")
                                        ),
                                    info: new Models.StudentSubModels.StudentPersonalInformation(
                                        gender: reader.GetString("gender"),
                                        birth_date: reader.GetDateTime("birth_date"),
                                        birth_address: reader.GetString("birth_address"),
                                        nationality: reader.GetString("nationality"),
                                        citizenship: reader.GetString("citizenship"),
                                        religion: reader.GetString("religion")
                                        ),
                                    contact: new Models.StudentSubModels.StudentContactInformation(
                                        contact_number: reader.GetString("contact_number"),
                                        email_address: reader.GetString("email_address")
                                        ),
                                    address: new Models.StudentSubModels.StudentAddressInformation(
                                        present_line1: reader.GetString("present_line1"),
                                        present_line2: reader.GetString("present_line2"),
                                        present_zip_code: reader.GetInt32("present_zip_code"),
                                        permanent_line1: reader.GetString("permanent_line1"),
                                        permanent_line2: reader.GetString("permanent_line2"),
                                        permanent_zip_code: reader.GetInt32("permanent_zip_code")
                                        ),
                                    family: new Models.StudentSubModels.StudentFamilyInformation(
                                        mother: new Models.StudentSubModels.GuardianAngel(
                                            name: reader.GetString("mother_name"),
                                            occupation: reader.GetString("mother_occupation"),
                                            contact_number: reader.GetString("mother_contact_number"),
                                            address: reader.GetString("mother_address")
                                            ),
                                        father: new Models.StudentSubModels.GuardianAngel(
                                            name: reader.GetString("father_name"),
                                            occupation: reader.GetString("father_occupation"),
                                            contact_number: reader.GetString("father_contact_number"),
                                            address: reader.GetString("father_address")
                                            ),
                                        guardian: new Models.StudentSubModels.GuardianAngel(
                                            name: reader.GetString("guardian_name"),
                                            occupation: reader.GetString("guardian_occupation"),
                                            contact_number: reader.GetString("guardian_contact_number"),
                                            address: reader.GetString("guardian_address")
                                            )
                                        ),
                                    academic_history: new Models.StudentSubModels.StudentAcademicHistory(
                                        last_school_attended: reader.GetString("last_school_attended"),
                                        last_school_attended_year: reader.GetInt32("last_school_attended_year"),
                                        secondary_school: reader.GetString("secondary_school"),
                                        secondary_school_year: reader.GetInt32("last_school_attended"),
                                        awards_received: reader.GetString("awards_received")
                                        )
                                )
                            );
                        }
                    }
                }
            }
            return users;
        }

        public List<UserModel> SearchUsers(string? username = null, string? full_name = null)
        {
            List<UserModel> users = new List<UserModel>();
            using (MySqlConnection connection = GetNewConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    if (username != null && full_name == null) // Search by username
                    {
                        command.CommandText = "SELECT * FROM users WHERE username LIKE @username";
                        command.Parameters.AddWithValue("@username", $"%{username}%");
                    }
                    else if (username == null && full_name != null) // Search by full name
                    {
                        command.CommandText = "SELECT * FROM users WHERE full_name LIKE @full_name";
                        command.Parameters.AddWithValue("@full_name", $"%{full_name}%");
                    }
                    else if (username != null && full_name != null) // Search by both username and full name
                    {
                        command.CommandText =
                            "SELECT * FROM users WHERE username LIKE @username AND full_name LIKE @full_name";
                        command.Parameters.AddWithValue("@username", $"%{username}%");
                        command.Parameters.AddWithValue("@full_name", $"%{full_name}%");
                    }
                    else // Get all users
                    {
                        command.CommandText = "SELECT * FROM users";
                    }

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(
                                new UserModel(
                                    user_id: reader.GetInt32("user_id"),
                                    username: reader.GetString("username"),
                                    userpass: reader.GetString("userpass"),
                                    privilege: (UserModel.Privilege)reader.GetInt32("privilege"),
                                    full_name: reader.IsDBNull(reader.GetOrdinal("full_name"))
                                        ? null
                                        : reader.GetString("full_name")
                                )
                            );
                        }
                    }
                }
            }
            return users;
        }
    }
}
