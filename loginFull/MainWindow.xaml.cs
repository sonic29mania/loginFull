using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace loginFull
{
    public partial class MainWindow : Window
    {
        private DatabaseManager dbManager;

        public MainWindow()
        {
            InitializeComponent();
            string connectionString = "User Id=root;Host=localhost;Database=flowertale; Password=root";
            dbManager = new DatabaseManager(connectionString);

            TestConnection();
        }

        private void TestConnection()
        {
            if (dbManager.TestConnection(out string errorMessage))
            {
                MessageBox.Show("Подключение успешно!");
            }
            else
            {
                MessageBox.Show($"Ошибка подключения: {errorMessage}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string surname = userSurname.Text;
            string name = username.Text;
            string emails = email.Text;
            string pass = password.Password;

            if (string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(emails) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Ошибка регистрации: Пожалуйста, заполните все поля.");
            }
            else
            {
                if (dbManager.RegisterUser(name, surname, emails, pass, out string errorMessage))
                {
                    MessageBox.Show("Вы успешно зарегистрировались!");
                }
                else
                {
                    MessageBox.Show($"Ошибка регистрации: {errorMessage}");
                }
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e) { }

        private void TextBox_TextChanged_1() { }

        private void userSurname_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) { }

        private void Email_TextChanged(object sender, TextChangedEventArgs e) { }

        private void TextBox_TextChanged_2(object sender, System.Windows.Controls.TextChangedEventArgs e) { }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем экземпляр окна Login
            login2 loginWindow = new login2();

            // Отображаем окно Login
            loginWindow.Show();

            // Закрываем текущее окно (если это необходимо)
            this.Close();

        }
        private void CloseIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close(); // Закрывает текущее окно
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
