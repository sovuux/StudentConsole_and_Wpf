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
        PersonLibrary.Student Student = new PersonLibrary.Student();
        public Add()
        {
            InitializeComponent();
        }

        private void Add_buttton_Click(object sender, RoutedEventArgs e)
        {

            if (Surname.Text != "" && Name.Text != "" && Patron.Text != "" && City.Text != "" && Pstindex.Text != "" && Street.Text != "" && Email.Text != "" && Number.Text != "" && Faculty.Text != "" && Specialty.Text != "" && Course.Text != "" && Group.Text != "")
            {

                Json.ReadJson(out List<PersonLibrary.Student> Students);
                Student.Fio.Surname = Surname.Text;
                Student.Fio.Name = Name.Text;
                Student.Fio.Patron = Patron.Text;
                Student.Address.City = City.Text;
                Student.Address.PstIndex = Pstindex.Text;
                Student.Address.Street = Street.Text;
                Student.Contacts.Mail = Email.Text;
                Student.Contacts.Phone = Number.Text;
                Student.Curriculum.Specialty = Specialty.Text;
                Student.Curriculum.Faculty = Faculty.Text;
                Student.Curriculum.Course = Course.Text;
                Student.Curriculum.Group = Group.Text;
                Data_SaveChanges(Students);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Вы не заполнили все строки!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Close_button(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        public void AllignId(List<PersonLibrary.Student> Students)
        {
            int[] stringId = new int[Students.Count];
            for (int index = 0; index < Students.Count; index++)
            {
                stringId[index] = index;
                Students[index].Id = index + 1;
            }
        }
        public void Data_SaveChanges(List<PersonLibrary.Student> Students)
        {
            Students.Add(Student);
            AllignId(Students);
            Json.WriteJson(Students);
        }
    }
}
