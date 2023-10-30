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
using PersonLibrary;
using StudentInterface;
using StudentJson;

namespace Student.Interface
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        PersonLibrary.Student student = new PersonLibrary.Student();
        public Add()
        {
            InitializeComponent();
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {

            if (Surname.Text != "" && Name.Text != "" && Patron.Text != "" && City.Text != "" && Pstindex.Text != "" && Street.Text != "" && Email.Text != "" && Number.Text != "" && Faculty.Text != "" && Specialty.Text != "" && Course.Text != "" && Group.Text != "")
            {

                Json.ReadJson(out List<PersonLibrary.Student> students);
                student.Fio.Surname = Surname.Text;
                student.Fio.Name = Name.Text;
                student.Fio.Patron = Patron.Text;
                student.Address.City = City.Text;
                student.Address.PstIndex = Pstindex.Text;
                student.Address.Street = Street.Text;
                student.Contacts.Mail = Email.Text;
                student.Contacts.Phone = Number.Text;
                student.Curriculum.Specialty = Specialty.Text;
                student.Curriculum.Faculty = Faculty.Text;
                student.Curriculum.Course = Course.Text;
                student.Curriculum.Group = Group.Text;
                SaveChangesData(students);
                ExitMenu();
            }
            else
            {
                MessageBox.Show("Вы не заполнили все строки!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void CloseButton(object sender, RoutedEventArgs e)
        {
            ExitMenu();
        }
        public void AllignId(List<PersonLibrary.Student> students)
        {
            int[] stringId = new int[students.Count];
            for (int index = 0; index < students.Count; index++)
            {
                stringId[index] = index;
                students[index].Id = index + 1;
            }
        }
        public void SaveChangesData(List<PersonLibrary.Student> students)
        {
            students.Add(student);
            AllignId(students);
            Json.WriteJson(students);
        }

        public void ExitMenu()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
