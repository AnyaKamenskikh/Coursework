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
    /// Логика взаимодействия для Pedagog.xaml
    /// </summary>
    public partial class Pedagog : Window
    {
        capitoshkaEntities db = new capitoshkaEntities();
        
        public Pedagog()
        {
            InitializeComponent();
            
        }

        private void ViewingWithUsers_Click(object sender, RoutedEventArgs e)
        {
            ViewingWithUsers viewingWithUsers = new ViewingWithUsers();
            viewingWithUsers.Show();
            Close();
        }

        private void ViewingEvents_Click(object sender, RoutedEventArgs e)
        {
            ViewingEvents viewingEvents = new ViewingEvents();
            viewingEvents.Show();
            Close();
        }

        private void ManagingGrpStd_Click(object sender, RoutedEventArgs e)
        {
            ManagingGrpStd grpStd = new ManagingGrpStd();
            grpStd.Show();
            Close();
        }

        private void WorkingWithChild_Click(object sender, RoutedEventArgs e)
        {
            WorkingWithChild workingWithChild = new WorkingWithChild();
            workingWithChild.Show();
            Close();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
