using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Capitoshka
{
    /// <summary>
    /// Логика взаимодействия для WorkingWithEvents.xaml
    /// </summary>
    public partial class WorkingWithEvents : Window
    {
        capitoshkaEntities db = new capitoshkaEntities();
        
        public WorkingWithEvents()
        {
            InitializeComponent();
           
            ListData.ItemsSource = db.Events.ToList();
            

            var type = db.TypeOfEvents.ToList();
            for (int i = 5; i < type.Count; i++)
            {
                Type.Items.Add(type[i].Name);
            }
        }

        private Events selectedEv;
        private void search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = search_Name.Text;

                // Ищем мероприятие в базе данных по наименованию
                selectedEv = db.Events.FirstOrDefault(p => p.Name == name);

                if (selectedEv != null)
                {
                    // Если мероприятие найдено, отображаем его данные в полях ввода
                    Name.Text = selectedEv.Name;
                    Type.Text = Convert.ToString(selectedEv.IDTypeOfEvents);
                    StartData.SelectedDate = selectedEv.StartDate;
                    ExpiratioData.SelectedDate = selectedEv.ExpirationDate;
                    
                }
                else
                {
                    MessageBox.Show("Мероприятие с таким названием не найдено.");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Edit2_Click(object sender, RoutedEventArgs e)
        {
            string typeOfEvents = Convert.ToString(selectedEv.IDTypeOfEvents);
            if (selectedEv != null)
            {
                // Вносим изменения в выбранный объект 
                selectedEv.Name = Name.Text;
                typeOfEvents = Type.Text;
                selectedEv.StartDate = StartData.SelectedDate;
                selectedEv.ExpirationDate = ExpiratioData.SelectedDate;
                


                // Обновляем информацию в ListView
                ListData.Items.Refresh();
                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Данные мероприятия успешно обновлены и сохранены в базе данных!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при сохранении данных: {ex.Message}");
                }
            }
        }

        private int typeSelection;
        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxTypeAdd.SelectedItem != null)
            {
                typeSelection = (int)ComboBoxTypeAdd.SelectedValue;
            }
        }

        private void ListData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (ListData.SelectedItem != null)
                {
                    // Сохраняем выбранный объект 
                    selectedEv = (Events)ListData.SelectedItem;

                    // Отображаем данные в полях ввода
                    Name.Text = selectedEv.Name;
                    Type.Text = Convert.ToString(selectedEv.IDTypeOfEvents);
                    StartData.SelectedDate = selectedEv.StartDate;
                    ExpiratioData.SelectedDate = selectedEv.ExpirationDate;
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                

                if (ComboBoxTypeAdd.SelectedItem != null)
                    {
                        int usll = (int)ComboBoxTypeAdd.SelectedValue;
                        var qwerty = db.TypeOfEvents.FirstOrDefault(x => x.ID == usll);
                        using (var context = new capitoshkaEntities())
                        {
                            var ev = new Events
                            {

                                Name = TextBoxNameAdd.Text,
                                IDTypeOfEvents = typeSelection,
                                StartDate = DataStartAdd.SelectedDate,
                                ExpirationDate = DataExpirationAdd.SelectedDate
                               
                            };
                            context.Events.Add(ev);
                            context.SaveChanges();
                            MessageBox.Show("Мероприятие успешно добавлено!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка");
                    }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void Exit3_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            Close();
        }
    }
}
