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

namespace Capitoshka
{
    /// <summary>
    /// Логика взаимодействия для ManagingGrpStd.xaml
    /// </summary>
    public partial class ManagingGrpStd : Window
    {
        capitoshkaEntities db = new capitoshkaEntities();
       
        List<Group> group = new List<Group>();

        public ManagingGrpStd()
        {
            InitializeComponent();
            
            var type = db.Direction.ToList();

            for (int i = 0; i < type.Count; i++)
            {
                ComboBoxTypeAdd.Items.Add(type[i].Name);
            }
        }

        
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TextBoxNameAdd.Text) || string.IsNullOrWhiteSpace(ComboBoxTypeAdd.Text))
                {
                    MessageBox.Show("Все поля обязательны к заполнению!");
                }
                else
                {
                    using (var context = new capitoshkaEntities())
                    {
                        var gr = new Group
                        {
                            Name = TextBoxNameAdd.Text,
                            IDDirection = typeSelection,
                        };
                        context.Group.Add(gr);
                        context.SaveChanges();
                        MessageBox.Show("Группа успешно добавлена!");
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private int typeSelection;
        private void ComboBoxTypeAdd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (ComboBoxTypeAdd.SelectedItem != null)
                {
                    typeSelection = (int)ComboBoxTypeAdd.SelectedValue;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Pedagog ped = new Pedagog();
            ped.Show();
            Close();
        }
    }
}
