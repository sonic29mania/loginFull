using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace loginFull
{

        public class DatabaseManager
        {
            private string connectionString;

            // Конструктор для инициализации строки подключения
            public DatabaseManager(string connectionString)
            {
                this.connectionString = connectionString;
            }

            // Метод для тестирования подключения
            public bool TestConnection(out string errorMessage)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        errorMessage = string.Empty;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        return false;
                    }
                }
            }

            // Метод для выполнения SQL-запроса на добавление пользователя
            public bool RegisterUser(string name, string surname, string email, string password, out string errorMessage)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        // Проверяем, существует ли пользователь с таким email
                        string checkQuery = "SELECT COUNT(*) FROM users WHERE user_email = @Email";
                        MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                        checkCmd.Parameters.AddWithValue("@Email", email);
                        int userExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (userExists > 0)
                        {
                            errorMessage = "Пользователь с таким email уже зарегистрирован.";
                            return false;
                        }

                        // SQL запрос для вставки нового пользователя
                        string query = "INSERT INTO users (user_name,user_surname,user_email, user_password) VALUES (@Name, @Surname, @Email, @Password)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Surname", surname);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            errorMessage = string.Empty;
                            return true;
                        }
                        else
                        {
                            errorMessage = "Ошибка при регистрации.";
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        return false;
                    }
                }
            }
        }
    
}
