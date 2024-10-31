using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Capitoshka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        capitoshkaEntities db = new capitoshkaEntities();
        Users users = new Users();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        public static class GlobalVariables
        {
            public static string UserLogin;
            public static string UserPassword;
        }

        private void Entrance_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            using (var Context = new capitoshkaEntities())
            {
                try
                {
                    var user = Context.Users.FirstOrDefault(u => u.Login == login);
                    if (user != null)
                    {
                        if (user.Password != password)
                        {
                            MessageBox.Show("Введен неверный пароль");
                        }
                        else
                        {
                            if (user != null)
                            {
                                // Проверка, является ли пользователь администратором
                                if (user.Post == 1)
                                {
                                    string rol = "Должность: Администратор";
                                    MessageBox.Show($"Авторизация успешна!\n" + user.Surname + " " + user.Name + " " + user.Patronymic + "\n" + rol);
                                    Admin admin = new Admin();
                                    admin.Show();
                                    Close();
                                    GlobalVariables.UserLogin = textBoxLogin.Text;
                                    GlobalVariables.UserPassword = textBoxPassword.Text;

                                }
                                // Проверка, является ли пользователь волонтёром
                                else if (user.Post == 2)
                                {
                                    string rol = "Должность: Педагог";
                                    MessageBox.Show($"Авторизация успешна!\n" + user.Surname + " " + user.Name + " " + user.Patronymic + "\n" + rol);
                                    Pedagog ped = new Pedagog();
                                    ped.Show();
                                    this.Close();
                                    GlobalVariables.UserLogin = textBoxLogin.Text;
                                    GlobalVariables.UserPassword = textBoxPassword.Text;

                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пользователь с такими данными не найден. Зарегистрируйтесь, чтобы продолжить.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при обработке запроса: {ex.Message}");
                }
            }
        }

        private void BtnMAska_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxPassword.Visibility == Visibility.Visible)
            {
                paswordPB.Visibility = Visibility.Visible;
                textBoxPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                paswordPB.Visibility = Visibility.Collapsed;
                textBoxPassword.Visibility = Visibility.Visible;
            }
            //скрытие пароля
        }

        private void textBoxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            paswordPB.Password = textBoxPassword.Text;
        }

        private void paswordPB_TextInput(object sender, TextCompositionEventArgs e)
        {
            textBoxPassword.Text = paswordPB.Password;
        }
    }
}
