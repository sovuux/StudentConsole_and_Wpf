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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        private PersonLibrary.Student c_student;
        public Edit(PersonLibrary.Student student)
        {
            InitializeComponent();
            c_student = student;
            surname.Text = c_student.Fio.Surname;
            name.Text = c_student.Fio.Name;
            patron.Text = c_student.Fio.Patron;
            city.Text = c_student.Address.City;
            pstindex.Text = c_student.Address.PstIndex;
            street.Text = c_student.Address.Street;
            email.Text = c_student.Contacts.Mail;
            number.Text = c_student.Contacts.Phone;
            faculty.Text = c_student.Curriculum.Faculty;
            specialty.Text = c_student.Curriculum.Specialty;
            course.Text = c_student.Curriculum.Course;
            group.Text = c_student.Curriculum.Group;
        }

        private void exit_Menu_but_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void fin_edit_but_Click(object sender, RoutedEventArgs e)
        {
            c_student.Fio.Surname = surname.Text;
            c_student.Fio.Name = name.Text;
            c_student.Fio.Patron = patron.Text;
            c_student.Address.City = city.Text;
            c_student.Address.PstIndex = pstindex.Text;
            c_student.Address.Street = street.Text;
            c_student.Contacts.Mail = email.Text;
            c_student.Contacts.Phone = number.Text;
            c_student.Curriculum.Specialty = specialty.Text;
            c_student.Curriculum.Faculty = faculty.Text;
            c_student.Curriculum.Course = course.Text;
            c_student.Curriculum.Group = group.Text;

            Json.ReadJson(out List<PersonLibrary.Student> students);
            int index = students.FindIndex(student => student.Id == c_student.Id);
            if (index != -1)
            {
                students[index] = c_student;
                Json.WriteJson(students);
                MessageBox.Show("Изменения сохранены успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();

        }
    }
}

