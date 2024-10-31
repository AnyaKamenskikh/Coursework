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
using Word = Microsoft.Office.Interop.Word;

namespace Capitoshka
{
    /// <summary>
    /// Логика взаимодействия для FormDocuments.xaml
    /// </summary>
    public partial class FormDocuments : Window
    {
        capitoshkaEntities db = new capitoshkaEntities();
        public FormDocuments()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            Close();
        }

        private void Repwo(string subToReplace, string text, Word.Document worddoc)
        {
            var range = worddoc.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: subToReplace, ReplaceWith: text);
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fio.Text) || string.IsNullOrWhiteSpace(name.Text))
                {
                    MessageBox.Show("Все поля обязательны к заполнению!");
                }
                else
                {
                    string d = DateTime.Now.ToString();
                    //создание документа в ворде
                    var WordApp = new Word.Application();
                    WordApp.Visible = false;

                    var Worddoc = WordApp.Documents.Open(Environment.CurrentDirectory + @"\documentss.docx");
                    Repwo("{data}", d, Worddoc);
                    Repwo("{fio}", "Иванов Иван Иванович", Worddoc);
                    string data = DateTime.Now.ToString();
                    Repwo("{name} ", "Название", Worddoc);

                    Worddoc.SaveAs2(Environment.CurrentDirectory + @"\documentss.docx");
                    Worddoc.Close();
                    WordApp.Quit();
                    MessageBox.Show("Договор создан!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при сохранении данных: {ex.Message}");
            }

        }
    }
}
