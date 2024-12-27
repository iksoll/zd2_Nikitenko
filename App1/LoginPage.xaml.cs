using App1;
using System;
using Xamarin.Forms;

namespace App1
{
    public partial class LoginPage :ContentPage
    {
        public LoginPage ()
        {
            InitializeComponent();
        }

        private void OnLoginClicked (object sender, EventArgs e)
        {
            // Получаем значения из полей ввода
            string login = LoginEntry.Text;
            string password = PasswordEntry.Text;

            // Проверка на пустые поля
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                DisplayAlert("Ошибка", "Пожалуйста, заполните все поля.", "OK");
                return;
            }

            // Проводим проверку логина и пароля
            if (login == "ipch" && password == "123456")
            {
                // Переход на главную страницу
                Application.Current.MainPage = new MainTabbedPage();
            } else
            {
                // Если данные неверны
                DisplayAlert("Ошибка", "Неверный логин или пароль.", "OK");
            }
        }
    }
}
