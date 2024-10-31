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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Capitoshka
{
    /// <summary>
    /// Логика взаимодействия для WorkngWithUsers.xaml
    /// </summary>
    public partial class WorkngWithUsers : Window
    {
        capitoshkaEntities db = new capitoshkaEntities();
        List<Users> users = new List<Users>();
        public WorkngWithUsers()
        {
            InitializeComponent();

            

            ListUsers.ItemsSource = db.Users.ToList();

            var post = db.Post.ToList();
            for (int i = 0; i < post.Count; i++)
            {
                ComboBoxPost.Items.Add(post[i].Name);
            }
            for (int i = 0; i < post.Count; i++)
            {
                ComboBoxPostAdd.Items.Add(post[i].Name);
            }

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TextBoxSurnameAdd.Text) || string.IsNullOrWhiteSpace(TextBoxNameAdd.Text) || string.IsNullOrWhiteSpace(TextBoxPatronimycAdd.Text) || string.IsNullOrWhiteSpace(DataBirthdayAdd.Text) || string.IsNullOrWhiteSpace(TextBoxPhoneAdd.Text) || string.IsNullOrWhiteSpace(ComboBoxPostAdd.Text) || string.IsNullOrWhiteSpace(TextBoxLoginAdd.Text) || string.IsNullOrWhiteSpace(TextBoxPassAdd.Text))
                {
                    MessageBox.Show("Все поля обязательны к заполнению!");
                }
                else
                {
                    
                        
                        
                            var us = new Users
                            {

                                Surname = TextBoxSurnameAdd.Text,
                                Name = TextBoxNameAdd.Text,
                                Patronymic = TextBoxPatronimycAdd.Text,
                                Birthday = DataBirthdayAdd.SelectedDate,
                                Phone = TextBoxPhoneAdd.Text,
                                Login = TextBoxLoginAdd.Text,
                                Password = TextBoxPassAdd.Text,
                                Post = ComboBoxPostAdd.SelectedIndex + 1,

                            };
                            db.Users.Add(us);
                            db.SaveChanges();
                            MessageBox.Show("Сотрудник успешно добавлен!");
                        
                    
                  
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private Users selectedPerson;
        private void Edit2_Click(object sender, RoutedEventArgs e)
        {
          
                if (selectedPerson != null)
                {
                    // Вносим изменения в выбранный объект Person
                    selectedPerson.Surname = TextBoxSurname.Text;
                    selectedPerson.Name = TextBoxName.Text;
                    selectedPerson.Patronymic = TextBoxPatronimyc.Text;
                    selectedPerson.Birthday = DataBirthday.SelectedDate;
                    selectedPerson.Phone = TextBoxPhohe.Text;
                    ComboBoxPost.Text = Convert.ToString(dolSelection);

                // Обновляем информацию в ListView
                ListUsers.Items.Refresh();
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Данные сотрудника успешно обновлены и сохранены в базе данных!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла ошибка при сохранении данных: {ex.Message}");
                    }
                }
            


        }


        private void Exit3_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            Close();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string фамилия = search_surname.Text;

                // Ищем сотрудника в базе данных по фамилии
                selectedPerson = db.Users.FirstOrDefault(p => p.Surname == фамилия);

                if (selectedPerson != null)
                {
                    // Если сотрудник найден, отображаем его данные в полях ввода
                    TextBoxSurname.Text = selectedPerson.Surname;
                    TextBoxName.Text = selectedPerson.Name;
                    TextBoxPatronimyc.Text = selectedPerson.Patronymic;
                    DataBirthday.SelectedDate = selectedPerson.Birthday;
                    TextBoxPhohe.Text = selectedPerson.Phone;
                    ComboBoxPost.Text = Convert.ToString(dolSelection);

                }
                else
                {
                    MessageBox.Show("Сотрудник с такой фамилией не найден.");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private int dolSelection;
        private void ComboBoxPost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (ComboBoxPost.SelectedItem != null)
                {
                    dolSelection = (int)ComboBoxPost.SelectedValue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ListUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListUsers.SelectedItem != null)
            {
                // Сохраняем выбранный объект Person
                selectedPerson = (Users)ListUsers.SelectedItem;

                // Отображаем данные в полях ввода
                TextBoxSurname.Text = selectedPerson.Surname;
                TextBoxName.Text = selectedPerson.Name;
                TextBoxPatronimyc.Text = selectedPerson.Patronymic;
                DataBirthday.SelectedDate = selectedPerson.Birthday;
                TextBoxPhohe.Text = selectedPerson.Phone;
                ComboBoxPost.Text = Convert.ToString(dolSelection);
            }
        }

        private void Exit1_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            Close();
        }
    }
}
