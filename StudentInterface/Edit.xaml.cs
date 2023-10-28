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
        private PersonLibrary.Student Edit_line;
        public Edit(PersonLibrary.Student Student)
        {
            InitializeComponent();
            Edit_line = Student;
            Surname.Text = Edit_line.Fio.Surname;
            Name.Text = Edit_line.Fio.Name;
            Patron.Text = Edit_line.Fio.Patron;
            City.Text = Edit_line.Address.City;
            Pstindex.Text = Edit_line.Address.PstIndex;
            Street.Text = Edit_line.Address.Street;
            Email.Text = Edit_line.Contacts.Mail;
            Number.Text = Edit_line.Contacts.Phone;
            Faculty.Text = Edit_line.Curriculum.Faculty;
            Specialty.Text = Edit_line.Curriculum.Specialty;
            Course.Text = Edit_line.Curriculum.Course;
            Group.Text = Edit_line.Curriculum.Group;
        }

        private void Exit_Menu_but_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Edit_but_Click(object sender, RoutedEventArgs e)
        {
                Edit_line.Fio.Surname = Surname.Text;
                Edit_line.Fio.Name = Name.Text;
                Edit_line.Fio.Patron = Patron.Text;
                Edit_line.Address.City = City.Text;
                Edit_line.Address.PstIndex = Pstindex.Text;
                Edit_line.Address.Street = Street.Text;
                Edit_line.Contacts.Mail = Email.Text;
                Edit_line.Contacts.Phone = Number.Text;
                Edit_line.Curriculum.Specialty = Specialty.Text;
                Edit_line.Curriculum.Faculty = Faculty.Text;
                Edit_line.Curriculum.Course = Course.Text;
                Edit_line.Curriculum.Group = Group.Text;
                Json.ReadJson(out List<PersonLibrary.Student> students);
                int index = students.FindIndex(student => student.Id == Edit_line.Id);
                if (index != -1)
                {
                    students[index] = Edit_line;
                    Json.WriteJson(students);
                    MessageBox.Show("Изменения сохранены успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
        }
    }

