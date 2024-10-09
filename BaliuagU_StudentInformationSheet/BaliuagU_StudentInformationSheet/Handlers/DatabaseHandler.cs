#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaliuagU_StudentInformationSheet.Handlers;
using BaliuagU_StudentInformationSheet.Models;
using BaliuagU_StudentInformationSheet.Models.StudentSubModels;
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
        public List<UserModel> GetAllUsers()
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

        public List<UserModel> SearchUsers(string? query = null)
        {
            List<UserModel> users = new List<UserModel>();
            using (MySqlConnection connection = GetNewConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    if (query == null) // Get all users
                        command.CommandText = "SELECT * FROM users";

                    else
                    {
                        command.CommandText = "SELECT * FROM users WHERE CONCAT_WS('', username, full_name) LIKE @query";
                        command.Parameters.AddWithValue("@query", $"%{query}%");
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

        public StudentModel GetStudent(string student_number)
        {
            StudentName name;
            StudentPersonalInformation info;
            StudentContactInformation contact;
            StudentAddressInformation address;
            StudentFamilyInformation family;
            StudentAcademicHistory academic_history;
            StudentPersonality personality;
            Image? photo = null;

            using (MySqlConnection connection = GetNewConnection())
            {
                connection.Open();

                // Get student name and personal information from `students` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM students WHERE student_number = @student_number";
                    command.Parameters.AddWithValue("@student_number", student_number);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new Exception("Student not found in database.");

                        name = new StudentName(
                            first: reader.GetString("first_name"),
                            middle: reader.IsDBNull(reader.GetOrdinal("middle_name"))
                                ? null
                                : reader.GetString("middle_name"),
                            last: reader.GetString("last_name")
                        );
                        photo = reader.IsDBNull(reader.GetOrdinal("photo"))
                            ? null
                            : ImageHandler.DecodeImage((byte[])reader["photo"]);
                        info = new StudentPersonalInformation(
                            gender: reader.GetString("gender"),
                            birth_date: reader.GetDateTime("birth_date"),
                            birth_address: reader.IsDBNull(reader.GetOrdinal("birth_address"))
                                ? null
                                : reader.GetString("birth_address"),
                            nationality: reader.GetString("nationality"),
                            citizenship: reader.GetString("citizenship"),
                            religion: reader.IsDBNull(reader.GetOrdinal("religion"))
                                ? null
                                : reader.GetString("religion")
                        );
                    }
                }

                // Get student contact information from `contact_information` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM contact_information WHERE id = @student_number";
                    command.Parameters.AddWithValue("@student_number", student_number);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new Exception("Student contact information not found in database.");

                        contact = new StudentContactInformation(
                            contact_number: reader.IsDBNull(reader.GetOrdinal("contact_number"))
                                ? null
                                : reader.GetString("contact_number"),
                            email_address: reader.IsDBNull(reader.GetOrdinal("email_address"))
                                ? null
                                : reader.GetString("email_address")
                        );
                    }
                }

                // Get student present address from `present_addresses` table
                // We need to get the present and permanent addresses separately
                // from the `present_addresses` and `permanent_addresses` tables
                // so we'll have to store the present address in temporary variables
                string? present_address_line1;
                string present_address_line2;
                int present_address_zip_code;
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM present_addresses WHERE id = @student_number";
                    command.Parameters.AddWithValue("@student_number", student_number);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new Exception("Student present address not found in database.");

                        present_address_line1 = reader.IsDBNull(reader.GetOrdinal("line1"))
                            ? null
                            : reader.GetString("line1");
                        present_address_line2 = reader.GetString("line2");
                        present_address_zip_code = reader.GetInt32("zip_code");
                    }
                }

                // Get student permanent address from `permanent_addresses` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM permanent_addresses WHERE id = @student_number";
                    command.Parameters.AddWithValue("@student_number", student_number);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new Exception("Student permanent address not found in database.");

                        // We can now assign the present and permanent addresses to the `address` variable
                        address = new StudentAddressInformation(
                            present_line1: present_address_line1,
                            present_line2: present_address_line2,
                            present_zip_code: present_address_zip_code,
                            permanent_line1: reader.IsDBNull(reader.GetOrdinal("line1"))
                                ? null
                                : reader.GetString("line1"),
                            permanent_line2: reader.GetString("line2"),
                            permanent_zip_code: reader.GetInt32("zip_code")
                        );
                    }
                }

                // Get student family information from `student_family` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM student_family WHERE id = @student_number";
                    command.Parameters.AddWithValue("@student_number", student_number);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new Exception("Student family information not found in database.");

                        GuardianAngel? mother = null, father = null, guardian = null;

                        if (
                            !reader.IsDBNull(reader.GetOrdinal("mother_name"))
                            || !reader.IsDBNull(reader.GetOrdinal("mother_occuation"))
                            || !reader.IsDBNull(reader.GetOrdinal("mother_contact_number"))
                            || !reader.IsDBNull(reader.GetOrdinal("mother_address"))
                        )
                            mother = new GuardianAngel(
                                name: reader.IsDBNull(reader.GetOrdinal("mother_name"))
                                    ? null
                                    : reader.GetString("mother_name"),
                                occupation: reader.IsDBNull(reader.GetOrdinal("mother_occupation"))
                                    ? null
                                    : reader.GetString("mother_occupation"),
                                contact_number: reader.IsDBNull(reader.GetOrdinal("mother_contact_number"))
                                    ? null
                                    : reader.GetString("mother_contact_number"),
                                address: reader.IsDBNull(reader.GetOrdinal("mother_address"))
                                    ? null
                                    : reader.GetString("mother_address")
                            );

                        if (
                            !reader.IsDBNull(reader.GetOrdinal("father_name"))
                            || !reader.IsDBNull(reader.GetOrdinal("father_occuation"))
                            || !reader.IsDBNull(reader.GetOrdinal("father_contact_number"))
                            || !reader.IsDBNull(reader.GetOrdinal("father_address"))
                        )
                            father = new GuardianAngel(
                                name: reader.IsDBNull(reader.GetOrdinal("father_name"))
                                    ? null
                                    : reader.GetString("father_name"),
                                occupation: reader.IsDBNull(reader.GetOrdinal("father_occupation"))
                                    ? null
                                    : reader.GetString("father_occupation"),
                                contact_number: reader.IsDBNull(reader.GetOrdinal("father_contact_number"))
                                    ? null
                                    : reader.GetString("father_contact_number"),
                                address: reader.IsDBNull(reader.GetOrdinal("father_address"))
                                    ? null
                                    : reader.GetString("father_address")
                            );

                        if (
                            !reader.IsDBNull(reader.GetOrdinal("guardian_name"))
                            || !reader.IsDBNull(reader.GetOrdinal("guardian_occuation"))
                            || !reader.IsDBNull(reader.GetOrdinal("guardian_contact_number"))
                            || !reader.IsDBNull(reader.GetOrdinal("guardian_address"))
                        )
                            guardian = new GuardianAngel(
                                name: reader.IsDBNull(reader.GetOrdinal("guardian_name"))
                                    ? null
                                    : reader.GetString("guardian_name"),
                                occupation: reader.IsDBNull(reader.GetOrdinal("guardian_occupation"))
                                    ? null
                                    : reader.GetString("guardian_occupation"),
                                contact_number: reader.IsDBNull(reader.GetOrdinal("guardian_contact_number"))
                                    ? null
                                    : reader.GetString("guardian_contact_number"),
                                address: reader.IsDBNull(reader.GetOrdinal("guardian_address"))
                                    ? null
                                    : reader.GetString("guardian_address")
                            );

                        family = new StudentFamilyInformation(
                            mother: mother,
                            father: father,
                            guardian: guardian
                        );
                    }
                }

                // Get student academic history from `academic_history` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM academic_history WHERE id = @student_number";
                    command.Parameters.AddWithValue("@student_number", student_number);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new Exception("Student academic history not found in database.");

                        academic_history = new StudentAcademicHistory(
                            last_school_attended: reader.IsDBNull(reader.GetOrdinal("last_school_attended"))
                                ? null
                                : reader.GetString("last_school_attended"),
                            last_school_attended_year: reader.IsDBNull(reader.GetOrdinal("last_school_attended_year"))
                                ? (int?)null
                                : reader.GetInt32("last_school_attended_year"),
                            secondary_school: reader.IsDBNull(reader.GetOrdinal("secondary_school"))
                                ? null
                                : reader.GetString("secondary_school"),
                            secondary_school_year: reader.IsDBNull(reader.GetOrdinal("secondary_school_year"))
                                ? (int?)null
                                : reader.GetInt32("secondary_school_year"),
                            awards_received: reader.IsDBNull(reader.GetOrdinal("awards_received"))
                                ? null
                                : reader.GetString("awards_received")
                            );
                    }
                }

                // Get student personality from `personalities` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM personalities WHERE id = @student_number";
                    command.Parameters.AddWithValue("@student_number", student_number);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new Exception("Student personality not found in database.");

                        personality = new StudentPersonality(
                            hobbies: reader.IsDBNull(reader.GetOrdinal("hobbies"))
                                ? null
                                : reader.GetString("hobbies"),
                            skills: reader.IsDBNull(reader.GetOrdinal("skills"))
                                ? null
                                : reader.GetString("skills")
                        );
                    }
                }

                return new StudentModel(
                    student_number: student_number,
                    name: name,
                    info: info,
                    contact: contact,
                    address: address,
                    family: family,
                    academic_history: academic_history,
                    personality: personality,
                    photo: photo
                );
            }
        }

        public void AddStudent(StudentModel student)
        {
            using (MySqlConnection connection = GetNewConnection())
            {
                connection.Open();

                // Save data to `students` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        "INSERT INTO "
                        + "students (student_number, "
                        + "name_first, name_middle, name_last, "
                        + "photo, gender, birth_date, birth_address, "
                        + "nationality, citizenship, religion) "
                        + "VALUES (@student_number, "
                        + "@name_first, @name_middle, @name_last, "
                        + "@photo, @gender, @birth_date, @birth_address, "
                        + "@nationality, @citizenship, @religion)";

                    command.Parameters.AddWithValue("@student_number", student.student_number);
                    command.Parameters.AddWithValue("@name_first", student.name.first);
                    command.Parameters.AddWithValue("@name_middle", student.name.middle);
                    command.Parameters.AddWithValue("@name_last", student.name.last);
                    command.Parameters.AddWithValue("@photo", ImageHandler.EncodeImage(student.photo));
                    command.Parameters.AddWithValue("@gender", student.info.gender);
                    command.Parameters.AddWithValue("@birth_date", student.info.birth_date);
                    command.Parameters.AddWithValue("@birth_address", student.info.birth_address);
                    command.Parameters.AddWithValue("@nationality", student.info.nationality);
                    command.Parameters.AddWithValue("@citizenship", student.info.citizenship);
                    command.Parameters.AddWithValue("@religion", student.info.religion);

                    if (command.ExecuteNonQuery() != 1)
                        throw new Exception("Failed to add student.");
                }

                // Save data to `contact_information` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        "INSERT INTO "
                        + "contact_information (id, contact_number, email_address) "
                        + "VALUES (@id, @contact_number, @email_address)";

                    command.Parameters.AddWithValue("@id", student.student_number);
                    command.Parameters.AddWithValue("@contact_number", student.contact.contact_number);
                    command.Parameters.AddWithValue("@email_address", student.contact.email_address);

                    if (command.ExecuteNonQuery() != 1)
                    {
                        // If it fails to add contact information, delete the student record
                        // to prevent orphaned records.
                        this.DeleteStudent(student.student_number, cleanup: true);
                        throw new Exception("Failed to add student contact information.");
                    }
                }

                // Save data to `present_addresses` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        "INSERT INTO "
                        + "present_addresses (id, line1, line2, zip_code) "
                        + "VALUES (@id, @line1, @line2, @zip_code)";

                    command.Parameters.AddWithValue("@id", student.student_number);
                    command.Parameters.AddWithValue("@line1", student.address.present_line1);
                    command.Parameters.AddWithValue("@line2", student.address.present_line2);
                    command.Parameters.AddWithValue("@zip_code", student.address.present_zip_code);

                    if (command.ExecuteNonQuery() != 1)
                    {
                        // If it fails to add contact information, delete the student record
                        // to prevent orphaned records.
                        this.DeleteStudent(student.student_number, cleanup: true);
                        throw new Exception("Failed to add student present address.");
                    }
                }

                // Save data to `permanent_addresses` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        "INSERT INTO "
                        + "permanent_addresses (id, line1, line2, zip_code) "
                        + "VALUES (@id, @line1, @line2, @zip_code)";

                    command.Parameters.AddWithValue("@id", student.student_number);
                    command.Parameters.AddWithValue("@line1", student.address.permanent_line1);
                    command.Parameters.AddWithValue("@line2", student.address.permanent_line2);
                    command.Parameters.AddWithValue("@zip_code", student.address.permanent_zip_code);

                    if (command.ExecuteNonQuery() != 1)
                    {
                        // If it fails to add contact information, delete the student record
                        // to prevent orphaned records.
                        this.DeleteStudent(student.student_number, cleanup: true);
                        throw new Exception("Failed to add student permanent address.");
                    }
                }

                // Save data to `student_family` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        "INSERT INTO "
                        + "student_family (id, mother_name, mother_occupation, mother_contact_number, mother_address, "
                        + "father_name, father_occupation, father_contact_number, father_address, "
                        + "guardian_name, guardian_occupation, guardian_contact_number, guardian_address) "
                        + "VALUES (@id, "
                        + "@mother_name, @mother_occupation, @mother_contact_number, @mother_address, "
                        + "@father_name, @father_occupation, @father_contact_number, @father_address, "
                        + "@guardian_name, @guardian_occupation, @guardian_contact_number, @guardian_address)";

                    command.Parameters.AddWithValue("@id", student.student_number);

                    if (student.family.mother != null)
                    {
                        command.Parameters.AddWithValue("@mother_name", student.family.mother.name);
                        command.Parameters.AddWithValue("@mother_occupation", student.family.mother.occupation);
                        command.Parameters.AddWithValue("@mother_contact_number", student.family.mother.contact_number);
                        command.Parameters.AddWithValue("@mother_address", student.family.mother.address);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@mother_name", DBNull.Value);
                        command.Parameters.AddWithValue("@mother_occupation", DBNull.Value);
                        command.Parameters.AddWithValue("@mother_contact_number", DBNull.Value);
                        command.Parameters.AddWithValue("@mother_address", DBNull.Value);
                    }

                    if (student.family.father != null)
                    {
                        command.Parameters.AddWithValue("@father_name", student.family.father.name);
                        command.Parameters.AddWithValue("@father_occupation", student.family.father.occupation);
                        command.Parameters.AddWithValue("@father_contact_number", student.family.father.contact_number);
                        command.Parameters.AddWithValue("@father_address", student.family.father.address);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@father_name", DBNull.Value);
                        command.Parameters.AddWithValue("@father_occupation", DBNull.Value);
                        command.Parameters.AddWithValue("@father_contact_number", DBNull.Value);
                        command.Parameters.AddWithValue("@father_address", DBNull.Value);
                    }

                    if (student.family.guardian != null)
                    {
                        command.Parameters.AddWithValue("@guardian_name", student.family.guardian.name);
                        command.Parameters.AddWithValue("@guardian_occupation", student.family.guardian.occupation);
                        command.Parameters.AddWithValue("@guardian_contact_number", student.family.guardian.contact_number);
                        command.Parameters.AddWithValue("@guardian_address", student.family.guardian.address);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@guardian_name", DBNull.Value);
                        command.Parameters.AddWithValue("@guardian_occupation", DBNull.Value);
                        command.Parameters.AddWithValue("@guardian_contact_number", DBNull.Value);
                        command.Parameters.AddWithValue("@guardian_address", DBNull.Value);
                    }

                    if (command.ExecuteNonQuery() != 1)
                    {
                        // If it fails to add contact information, delete the student record
                        // to prevent orphaned records.
                        this.DeleteStudent(student.student_number, cleanup: true);
                        throw new Exception("Failed to add student family information.");
                    }
                }

                // Save data to `academic_history` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        "INSERT INTO "
                        + "academic_history (id, last_school_attended, last_school_attended_year, "
                        + "secondary_school, secondary_school_year, awards_received) "
                        + "VALUES (@id, "
                        + "@last_school_attended, @last_school_attended_year, "
                        + "@secondary_school, @secondary_school_year, @awards_received)";

                    command.Parameters.AddWithValue("@id", student.student_number);
                    command.Parameters.AddWithValue("@last_school_attended", student.academic_history.last_school_attended);
                    command.Parameters.AddWithValue("@last_school_attended_year", student.academic_history.last_school_attended_year);
                    command.Parameters.AddWithValue("@secondary_school", student.academic_history.secondary_school);
                    command.Parameters.AddWithValue("@secondary_school_year", student.academic_history.secondary_school_year);
                    command.Parameters.AddWithValue("@awards_received", student.academic_history.awards_received);

                    if (command.ExecuteNonQuery() != 1)
                    {
                        // If it fails to add contact information, delete the student record
                        // to prevent orphaned records.
                        this.DeleteStudent(student.student_number, cleanup: true);
                        throw new Exception("Failed to add student academic history.");
                    }
                }

                // Save data to `personalities` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        "INSERT INTO "
                        + "personalities (id, hobbies, skills) "
                        + "VALUES (@id, @hobbies, @skills)";

                    command.Parameters.AddWithValue("@id", student.student_number);
                    command.Parameters.AddWithValue("@hobbies", student.personality.hobbies);
                    command.Parameters.AddWithValue("@skills", student.personality.skills);

                    if (command.ExecuteNonQuery() != 1)
                    {
                        // If it fails to add contact information, delete the student record
                        // to prevent orphaned records.
                        this.DeleteStudent(student.student_number, cleanup: true);
                        throw new Exception("Failed to add student personality.");
                    }
                }
            }
        }

        public void UpdateStudent(StudentModel student)
        {
            using (MySqlConnection connection = GetNewConnection())
            {
                connection.Open();

                // Update data in `students` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE students SET "
                        + "name_first = @name_first, name_middle = @name_middle, name_last = @name_last, "
                        + "photo = @photo, "
                        + "gender = @gender, birth_date = @birth_date, birth_address = @birth_address, "
                        + "nationality = @nationality, citizenship = @citizenship, religion = @religion ";

                    command.Parameters.AddWithValue("@student_number", student.student_number);
                    command.Parameters.AddWithValue("@name_first", student.name.first);
                    command.Parameters.AddWithValue("@name_middle", student.name.middle);
                    command.Parameters.AddWithValue("@name_last", student.name.last);
                    command.Parameters.AddWithValue("@photo", ImageHandler.EncodeImage(student.photo));
                    command.Parameters.AddWithValue("@gender", student.info.gender);
                    command.Parameters.AddWithValue("@birth_date", student.info.birth_date);
                    command.Parameters.AddWithValue("@birth_address", student.info.birth_address);
                    command.Parameters.AddWithValue("@nationality", student.info.nationality);
                    command.Parameters.AddWithValue("@citizenship", student.info.citizenship);
                    command.Parameters.AddWithValue("@religion", student.info.religion);

                    if (command.ExecuteNonQuery() != 1)
                        throw new Exception("Failed to update student.");
                }

                // Update data in `contact_information` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE contact_information SET "
                        + "contact_number = @contact_number, email_address = @email_address "
                        + "WHERE id = @student_number";

                    command.Parameters.AddWithValue("@student_number", student.student_number);
                    command.Parameters.AddWithValue("@contact_number", student.contact.contact_number);
                    command.Parameters.AddWithValue("@email_address", student.contact.email_address);

                    if (command.ExecuteNonQuery() != 1)
                        throw new Exception("Failed to update student contact information.");
                }

                // Update data in `present_addresses` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE present_addresses SET "
                        + "line1 = @line1, line2 = @line2, zip_code = @zip_code "
                        + "WHERE id = @student_number";

                    command.Parameters.AddWithValue("@student_number", student.student_number);
                    command.Parameters.AddWithValue("@line1", student.address.present_line1);
                    command.Parameters.AddWithValue("@line2", student.address.present_line2);
                    command.Parameters.AddWithValue("@zip_code", student.address.present_zip_code);

                    if (command.ExecuteNonQuery() != 1)
                        throw new Exception("Failed to update student present address.");
                }

                // Update data in `permanent_addresses` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE permanent_addresses SET "
                        + "line1 = @line1, line2 = @line2, zip_code = @zip_code "
                        + "WHERE id = @student_number";

                    command.Parameters.AddWithValue("@student_number", student.student_number);
                    command.Parameters.AddWithValue("@line1", student.address.permanent_line1);
                    command.Parameters.AddWithValue("@line2", student.address.permanent_line2);
                    command.Parameters.AddWithValue("@zip_code", student.address.permanent_zip_code);

                    if (command.ExecuteNonQuery() != 1)
                        throw new Exception("Failed to update student permanent address.");
                }

                // Update data in `student_family` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE student_family SET "
                        + "mother_name = @mother_name, mother_occupation = @mother_occupation, "
                        + "mother_contact_number = @mother_contact_number, mother_address = @mother_address, "
                        + "father_name = @father_name, father_occupation = @father_occupation, "
                        + "father_contact_number = @father_contact_number, father_address = @father_address, "
                        + "guardian_name = @guardian_name, guardian_occupation = @guardian_occupation, "
                        + "guardian_contact_number = @guardian_contact_number, guardian_address = @guardian_address "
                        + "WHERE id = @student_number";

                    command.Parameters.AddWithValue("@student_number", student.student_number);

                    if (student.family.mother != null)
                    {
                        command.Parameters.AddWithValue("@mother_name", student.family.mother.name);
                        command.Parameters.AddWithValue("@mother_occupation", student.family.mother.occupation);
                        command.Parameters.AddWithValue("@mother_contact_number", student.family.mother.contact_number);
                        command.Parameters.AddWithValue("@mother_address", student.family.mother.address);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@mother_name", DBNull.Value);
                        command.Parameters.AddWithValue("@mother_occupation", DBNull.Value);
                        command.Parameters.AddWithValue("@mother_contact_number", DBNull.Value);
                        command.Parameters.AddWithValue("@mother_address", DBNull.Value);
                    }

                    if (student.family.father != null)
                    {
                        command.Parameters.AddWithValue("@father_name", student.family.father.name);
                        command.Parameters.AddWithValue("@father_occupation", student.family.father.occupation);
                        command.Parameters.AddWithValue("@father_contact_number", student.family.father.contact_number);
                        command.Parameters.AddWithValue("@father_address", student.family.father.address);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@father_name", DBNull.Value);
                        command.Parameters.AddWithValue("@father_occupation", DBNull.Value);
                        command.Parameters.AddWithValue("@father_contact_number", DBNull.Value);
                        command.Parameters.AddWithValue("@father_address", DBNull.Value);
                    }

                    if (student.family.guardian != null)
                    {
                        command.Parameters.AddWithValue("@guardian_name", student.family.guardian.name);
                        command.Parameters.AddWithValue("@guardian_occupation", student.family.guardian.occupation);
                        command.Parameters.AddWithValue("@guardian_contact_number", student.family.guardian.contact_number);
                        command.Parameters.AddWithValue("@guardian_address", student.family.guardian.address);
                    }
                }

                // Update data in `academic_history` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE academic_history SET "
                        + "last_school_attended = @last_school_attended, last_school_attended_year = @last_school_attended_year, "
                        + "secondary_school = @secondary_school, secondary_school_year = @secondary_school_year, "
                        + "awards_received = @awards_received "
                        + "WHERE id = @student_number";

                    command.Parameters.AddWithValue("@student_number", student.student_number);
                    command.Parameters.AddWithValue("@last_school_attended", student.academic_history.last_school_attended);
                    command.Parameters.AddWithValue("@last_school_attended_year", student.academic_history.last_school_attended_year);
                    command.Parameters.AddWithValue("@secondary_school", student.academic_history.secondary_school);
                    command.Parameters.AddWithValue("@secondary_school_year", student.academic_history.secondary_school_year);
                    command.Parameters.AddWithValue("@awards_received", student.academic_history.awards_received);

                    if (command.ExecuteNonQuery() != 1)
                        throw new Exception("Failed to update student academic history.");
                }

                // Update data in `personalities` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE personalities SET "
                        + "hobbies = @hobbies, skills = @skills "
                        + "WHERE id = @student_number";

                    command.Parameters.AddWithValue("@student_number", student.student_number);
                    command.Parameters.AddWithValue("@hobbies", student.personality.hobbies);
                    command.Parameters.AddWithValue("@skills", student.personality.skills);

                    if (command.ExecuteNonQuery() != 1)
                        throw new Exception("Failed to update student personality.");
                }
            }
        }

        /// <summary>
        /// Delete a student from the database.
        /// </summary>
        /// <param name="student_number">The student number of the student to delete.</param>
        /// <param name="cleanup">If true, do not throw an exception when it fails to delete a record from a table.</param>
        public void DeleteStudent(string student_number, bool cleanup = false)
        {
            using (MySqlConnection connection = GetNewConnection())
            {
                connection.Open();

                // Delete data from `students` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM students WHERE student_number = @student_number";
                    command.Parameters.AddWithValue("@student_number", student_number);

                    if (command.ExecuteNonQuery() != 1)
                        if (!cleanup)
                            throw new Exception("Failed to delete student.");
                }

                // Delete data from `contact_information` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM contact_information WHERE id = @student_number";
                    command.Parameters.AddWithValue("@student_number", student_number);

                    if (command.ExecuteNonQuery() != 1)
                        if (!cleanup)
                            throw new Exception("Failed to delete student contact information.");
                }

                // Delete data from `present_addresses` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM present_addresses WHERE id = @student_number";
                    command.Parameters.AddWithValue("@student_number", student_number);

                    if (command.ExecuteNonQuery() != 1)
                        if (!cleanup)
                            throw new Exception("Failed to delete student present address.");
                }

                // Delete data from `permanent_addresses` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM permanent_addresses WHERE id = @student_number";
                    command.Parameters.AddWithValue("@student_number", student_number);

                    if (command.ExecuteNonQuery() != 1)
                        if (!cleanup)
                            throw new Exception("Failed to delete student permanent address.");
                }

                // Delete data from `student_family` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM student_family WHERE id = @student_number";
                    command.Parameters.AddWithValue("@student_number", student_number);

                    if (command.ExecuteNonQuery() != 1)
                        if (!cleanup)
                            throw new Exception("Failed to delete student family information.");
                }

                // Delete data from `academic_history` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM academic_history WHERE id = @student_number";
                    command.Parameters.AddWithValue("@student_number", student_number);

                    if (command.ExecuteNonQuery() != 1)
                        if (!cleanup)
                            throw new Exception("Failed to delete student academic history.");
                }

                // Delete data from `personalities` table
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM personalities WHERE id = @student_number";
                    command.Parameters.AddWithValue("@student_number", student_number);

                    if (command.ExecuteNonQuery() != 1)
                        if (!cleanup)
                            throw new Exception("Failed to delete student personality.");
                }
            }
        }

        public List<StudentModel> GetAllStudents()
        {
            List<string> students = new List<string>();
            using (MySqlConnection connection = GetNewConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT student_number FROM students";
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(reader.GetString("student_number"));
                        }
                    }
                }
            }

            List<StudentModel> student_models = new List<StudentModel>();
            foreach (string student_number in students)
                student_models.Add(this.GetStudent(student_number));

            return student_models;
        }

        public List<StudentModel> SearchStudents(string? query = null)
        {
            List<string> students = new List<string>();
            using (MySqlConnection connection = GetNewConnection())
            {
                connection.Open();
                // Search for student numbers and for first, middle, and last names
                using (MySqlCommand command = connection.CreateCommand())
                {
                    if (query == null)
                        command.CommandText = "SELECT student_number FROM students";
                    else
                    {
                        command.CommandText = "SELECT student_number FROM students WHERE CONCAT_WS('', student_number, name_first, name_middle, name_last) LIKE @query";
                        command.Parameters.AddWithValue("@query", $"%{query}%");
                    }

                    using (MySqlDataReader reader = command.ExecuteReader())
                        while (reader.Read())
                            students.Add(reader.GetString("student_number"));
                }

                List<StudentModel> student_models = new List<StudentModel>();
                foreach (string student_number in students)
                    student_models.Add(this.GetStudent(student_number));

                return student_models;
            }
        }
    }
}
