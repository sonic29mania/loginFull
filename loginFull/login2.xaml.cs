using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace loginFull
{
    public partial class login2 : Window
    {
        public login2()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void Email_TextChanged(object sender, TextChangedEventArgs e) { }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string emails = email.Text;
            
            if(string.IsNullOrWhiteSpace(emails) || string.IsNullOrWhiteSpace(password.Password))
            {
                MessageBox.Show("Ошибка регистрации: Пожалуйста, заполните все поля.");
            }
            else
            {
                MessageBox.Show("Авторизация прошла успешно!"); 
            }
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow signUp = new MainWindow();
            signUp.Show();
            this.Close();
        }
        private void CloseIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close(); // Закрывает текущее окно
        }       
    }
}
