using SecurityAgencyIS.Models;
using SecurityAgencyIS.View.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace SecurityAgencyIS.Presenter
{
    public class RegistrationPresenter
    {
        IRegistration _registration { get; set; }

        public RegistrationPresenter(IRegistration registration)
        {
            _registration = registration;
            _registration.RegistrationButton += RegistrationButton;
        }

        public void RegistrationButton(object sender, EventArgs e)
        {
            string login = _registration.userLogin;
            string password = _registration.userPassword;
            string role = _registration.userRole;
            string adminPassword = _registration.adminPassword;

            DBManage dataBase = new DBManage();

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Логин и пароль обязательны для заполнения.", "Ошибка регистрации");
                return;
            }

            if (dataBase.UserExists(login))
            {
                MessageBox.Show("Пользователь с таким логином уже существует. Выберите другой логин.", "Пользователь существует");
                return;
            }

            if (string.IsNullOrWhiteSpace(role))
            {
                role = "user";
            }
            else if (role != "admin" && role != "user" && role != "manager")
            {
                MessageBox.Show("Вы ввели неверные данные. Доступные роли: admin, user, manager.", "Ошибка роли");
                return;
            }

            if (role == "admin" || role == "manager")
            {
                string expectedAdminPassword = "admin";
                if (adminPassword != expectedAdminPassword)
                {
                    MessageBox.Show("Неверный пароль администратора. Вы не можете назначить роль admin.", "Ошибка роли");
                    return;
                }
            }

            PasswordHash passwordHash = new PasswordHash();
            (string hashedPassword, string salt) = passwordHash.HashPasswordWithSalt(password);

            dataBase.InsertUser(login, hashedPassword, role, salt);

            MessageBox.Show("Пользователь успешно зарегестрирован!", "Регистрация завершена");

            MessageBox.Show($"Логин: {login}\nХэшированный пароль: {salt}", "Хэширование пароля");
        }
    }
}
