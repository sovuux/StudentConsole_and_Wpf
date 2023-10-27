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
        private PersonLibrary.Student window_Edit_line;
        public Edit(PersonLibrary.Student student)
        {
            InitializeComponent();
            window_Edit_line = student;
            surname.Text = window_Edit_line.Fio.Surname;
            name.Text = window_Edit_line.Fio.Name;
            patron.Text = window_Edit_line.Fio.Patron;
            city.Text = window_Edit_line.Address.City;
            pstindex.Text = window_Edit_line.Address.PstIndex;
            street.Text = window_Edit_line.Address.Street;
            email.Text = window_Edit_line.Contacts.Mail;
            number.Text = window_Edit_line.Contacts.Phone;
            faculty.Text = window_Edit_line.Curriculum.Faculty;
            specialty.Text = window_Edit_line.Curriculum.Specialty;
            course.Text = window_Edit_line.Curriculum.Course;
            group.Text = window_Edit_line.Curriculum.Group;
        }

        private void exit_Menu_but_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void fin_edit_but_Click(object sender, RoutedEventArgs e)
        {
                window_Edit_line.Fio.Surname = surname.Text;
                window_Edit_line.Fio.Name = name.Text;
                window_Edit_line.Fio.Patron = patron.Text;
                window_Edit_line.Address.City = city.Text;
                window_Edit_line.Address.PstIndex = pstindex.Text;
                window_Edit_line.Address.Street = street.Text;
                window_Edit_line.Contacts.Mail = email.Text;
                window_Edit_line.Contacts.Phone = number.Text;
                window_Edit_line.Curriculum.Specialty = specialty.Text;
                window_Edit_line.Curriculum.Faculty = faculty.Text;
                window_Edit_line.Curriculum.Course = course.Text;
                window_Edit_line.Curriculum.Group = group.Text;
                Json.ReadJson(out List<PersonLibrary.Student> students);
                int index = students.FindIndex(student => student.Id == window_Edit_line.Id);
                if (index != -1)
                {
                    students[index] = window_Edit_line;
                    Json.WriteJson(students);
                    MessageBox.Show("Изменения сохранены успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
        }
    }

