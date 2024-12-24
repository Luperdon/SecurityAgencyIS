using SecurityAgencyIS.View.Interface;
using SecurityAgencyIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityAgencyIS.Presenter
{
    public class LoginPresenter
    {
        ILogin _login { get; set; }
        public LoginPresenter(ILogin login)
        {
            _login = login;
            _login.OpenRegistrationWindow += OpenRegWindow;
            _login.OpenMainWindow += OpenMainWindow;
        }

        private void OpenRegWindow(object args, EventArgs e)
        {
            RegistrationWindow regWindow = new RegistrationWindow();
            regWindow.ShowDialog();
        }

        private void OpenMainWindow(object args, EventArgs e)
        {
            string login = _login.userLogin;
            string password = _login.userPassword;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Логин и пароль обязательны для заполнения.", "Ошибка регистрации");
                return;
            }

            User user = new User();
            user.AuthenticateUser(login, password);

            if (!user.isLoginExists)
            {
                MessageBox.Show("Пользователя с таким логином не существует.", "Пользователь не найден");
                return;
            }
            else if (!user.isPasswordValid)
            {
                MessageBox.Show("Неверный пароль", "Ошибка");
                return;
            }
            MessageBox.Show($"Роль: {user.role}");
            // Успешный вход
            MainWindow mainWindow = new MainWindow(user.role);
            // Открытие главного окна
            mainWindow.ShowDialog();
        }

    }
}