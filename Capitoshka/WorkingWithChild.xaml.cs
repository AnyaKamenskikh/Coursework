using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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

namespace Capitoshka
{
    /// <summary>
    /// Логика взаимодействия для WorkingWithChild.xaml
    /// </summary>
    public partial class WorkingWithChild : Window
    {
        capitoshkaEntities db = new capitoshkaEntities();
        
        Child child = new Child();
        public WorkingWithChild()
        {
            InitializeComponent();
            
            ListChild.ItemsSource = db.Child.ToList();
            

            var par = db.Parents.ToList();
            for (int i = 0; i < par.Count; i++)
            {
                ComboBoxParent.Items.Add(par[i].Surname);
            }
            for (int i = 0; i < par.Count; i++)
            {
                ComboBoxParentAdd.Items.Add(par[i].Surname);
            }
        }

        private Child selectedch;
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            
            if (selectedch != null)
            {
                // Вносим изменения в выбранный объект 
                selectedch.Surname = TextBoxSurname.Text;
                selectedch.Name = TextBoxName.Text;
                selectedch.Patronymic = TextBoxPatronimyc.Text;
                selectedch.Birthday = DataBirthday.SelectedDate;
                selectedch.IDParent = Convert.ToInt32(ComboBoxParent.Text);



                // Обновляем информацию в ListView
                ListChild.Items.Refresh();
                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Данные о ребенке успешно обновлены и сохранены в базе данных!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при сохранении данных: {ex.Message}");
                }
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string surname = search_Surname.Text;

                // Ищем мероприятие в базе данных по наименованию
                selectedch = db.Child.FirstOrDefault(p => p.Surname == surname);

                if (selectedch != null)
                {
                    // Если мероприятие найдено, отображаем его данные в полях ввода
                    TextBoxSurname.Text = selectedch.Surname;
                    TextBoxName.Text =selectedch.Name;
                    TextBoxPatronimyc.Text = selectedch.Patronymic;
                    DataBirthday.SelectedDate = selectedch.Birthday;
                    ComboBoxParent.Text = Convert.ToString(selectedch.IDParent);

                }
                else
                {
                    MessageBox.Show("Ребенка с такой фамилией не найдено.");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Pedagog pedagog = new Pedagog();
            pedagog.Show();
            Close();
        }

        private void Exit3_Click(object sender, RoutedEventArgs e)
        {
            Pedagog pedagog = new Pedagog();
            pedagog.Show();
            Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TextBoxSurnameAdd.Text) || string.IsNullOrWhiteSpace(TextBoxNameAdd.Text) || string.IsNullOrWhiteSpace(TextBoxPatronimycAdd.Text) || string.IsNullOrWhiteSpace(DataBirthdayAdd.Text) || string.IsNullOrWhiteSpace(ComboBoxParentAdd.Text))
                {
                    MessageBox.Show("Все поля обязательны к заполнению!");
                }
                else
                {
                        using (var context = new capitoshkaEntities())
                        {
                            var us = new Child
                            {

                                Surname = TextBoxSurnameAdd.Text,
                                Name = TextBoxNameAdd.Text,
                                Patronymic = TextBoxPatronimycAdd.Text,
                                Birthday = DataBirthdayAdd.SelectedDate,
                                IDParent = ComboBoxParentAdd.SelectedIndex + 1,
                                
                            };
                            context.Child.Add(us);
                            context.SaveChanges();
                            MessageBox.Show("Ребенок успешно добавлен!");
                        }
                    
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ListChild_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (ListChild.SelectedItem != null)
                {
                    // Сохраняем выбранный объект 
                    selectedch = (Child)ListChild.SelectedItem;

                    // Отображаем данные в полях ввода
                    TextBoxSurname.Text = selectedch.Surname;
                    TextBoxName.Text = selectedch.Name;
                    TextBoxPatronimyc.Text = selectedch.Patronymic;
                    DataBirthday.SelectedDate = selectedch.Birthday;
                    ComboBoxParent.Text = Convert.ToString(selectedch.IDParent);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private int parSelection;
        private void ComboBoxParent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxParent.SelectedItem != null)
            {
                parSelection = (int)ComboBoxParent.SelectedValue;
            }
        }

        private void AddPar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TextBoxSurnameAddPar.Text) || string.IsNullOrWhiteSpace(TextBoxNameAddPar.Text) || string.IsNullOrWhiteSpace(TextBoxPatronimycAddPar.Text) || string.IsNullOrWhiteSpace(DataBirthdayAddPar.Text) || string.IsNullOrWhiteSpace(TextBoxPlaceOfWorkAddPar.Text) || string.IsNullOrWhiteSpace(TextBoxPhoneAddPar.Text))
                {
                    MessageBox.Show("Все поля обязательны к заполнению!");
                }
                else
                {
                    using (var context = new capitoshkaEntities())
                    {
                        var pr = new Parents
                        {

                            Surname = TextBoxSurnameAdd.Text,
                            Name = TextBoxNameAdd.Text,
                            Patronymic = TextBoxPatronimycAdd.Text,
                            Birthday = DataBirthdayAdd.SelectedDate,
                            PlaceOfWork = TextBoxPlaceOfWorkAddPar.Text,
                            Phone = TextBoxPhoneAddPar.Text,
                        };
                        context.Parents.Add(pr);
                        context.SaveChanges();
                        MessageBox.Show("Родитель успешно добавлен!");
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
