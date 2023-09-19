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

        private void fin_add_but_Click(object sender, RoutedEventArgs e)
        {
           
            if (surname.Text != "" && name.Text != "" && patron.Text != "" && city.Text != "" && pstindex.Text != "" && street.Text != "" && email.Text != "" && number.Text != "" && faculty.Text != "" && specialty.Text != "" && course.Text != "" && group.Text != "")
            {
                Json.ReadJson(out List<PersonLibrary.Student> students);
                student.Fio.Surname = surname.Text;
                student.Fio.Name = name.Text;
                student.Fio.Patron = patron.Text;
                student.Address.City = city.Text;
                student.Address.PstIndex = pstindex.Text;
                student.Address.Street = street.Text;
                student.Contacts.Mail = email.Text;
                student.Contacts.Phone = number.Text;
                student.Curriculum.Specialty= specialty.Text;
                student.Curriculum.Faculty = faculty.Text;
                student.Curriculum.Course = course.Text;    
                student.Curriculum.Group = group.Text;
                students.Add(student);
                Json.WriteJson(students);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();

            }
            else
            {
               MessageBox.Show("Вы не заполнили все строки!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void close_but(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
