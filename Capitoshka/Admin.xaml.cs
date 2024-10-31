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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        capitoshkaEntities db = new capitoshkaEntities();
        
        public Admin()
        {
            InitializeComponent();
            
            
        }

        private void WorkngWithUsers_Click(object sender, RoutedEventArgs e)
        {
            WorkngWithUsers workingWithUsers = new WorkngWithUsers();
            workingWithUsers.Show();
            Close();
        }

        private void WorkingWithEvents_Click(object sender, RoutedEventArgs e)
        {
            WorkingWithEvents workingWithEvents = new WorkingWithEvents();
            workingWithEvents.Show();
            Close();
        }

        private void FormDocuments_Click(object sender, RoutedEventArgs e)
        {
            FormDocuments formDocuments = new FormDocuments();
            formDocuments.Show();
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
