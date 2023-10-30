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
        private PersonLibrary.Student RowForEdit;
        public Edit(PersonLibrary.Student student)
        {
            InitializeComponent();
            RowForEdit = student;
            Surname.Text = RowForEdit.Fio.Surname;
            Name.Text = RowForEdit.Fio.Name;
            Patron.Text = RowForEdit.Fio.Patron;
            City.Text = RowForEdit.Address.City;
            Pstindex.Text = RowForEdit.Address.PstIndex;
            Street.Text = RowForEdit.Address.Street;
            Email.Text = RowForEdit.Contacts.Mail;
            Number.Text = RowForEdit.Contacts.Phone;
            Faculty.Text = RowForEdit.Curriculum.Faculty;
            Specialty.Text = RowForEdit.Curriculum.Specialty;
            Course.Text = RowForEdit.Curriculum.Course;
            Group.Text = RowForEdit.Curriculum.Group;
        }

        private void ExitMenuButton(object sender, RoutedEventArgs e)
        {
            ExitMenu();
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
                RowForEdit.Fio.Surname = Surname.Text;
                RowForEdit.Fio.Name = Name.Text;
                RowForEdit.Fio.Patron = Patron.Text;
                RowForEdit.Address.City = City.Text;
                RowForEdit.Address.PstIndex = Pstindex.Text;
                RowForEdit.Address.Street = Street.Text;
                RowForEdit.Contacts.Mail = Email.Text;
                RowForEdit.Contacts.Phone = Number.Text;
                RowForEdit.Curriculum.Specialty = Specialty.Text;
                RowForEdit.Curriculum.Faculty = Faculty.Text;
                RowForEdit.Curriculum.Course = Course.Text;
                RowForEdit.Curriculum.Group = Group.Text;
                Json.ReadJson(out List<PersonLibrary.Student> students);
                int index = students.FindIndex(student => student.Id == RowForEdit.Id);
                if (index != -1)
                {
                    students[index] = RowForEdit;
                    Json.WriteJson(students);
                    MessageBox.Show("Изменения сохранены успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                ExitMenu();
        }

        public void ExitMenu()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

    }
}

