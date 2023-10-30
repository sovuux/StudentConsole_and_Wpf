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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Xaml;
using PersonLibrary;
using Student.Interface;
using StudentJson;
using System.Windows.Controls.Primitives;
using System.IO;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace StudentInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
       
        void LoadData()
        {
            Json.ReadJson(out List<PersonLibrary.Student> students);
            DataGrid.ItemsSource = students;
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
        void DeleteButton(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
            {
                DeleteRow();
            }
            else
            {
                MessageBox.Show("Выберите строку(и) для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }
        
        public void DeleteRow()
        {
            Json.ReadJson(out List<PersonLibrary.Student> students);
            PersonLibrary.Student selectedStudent = (PersonLibrary.Student)DataGrid.SelectedItem;
            if (students != null)
            {
                MessageBoxResult result = MessageBox.Show($"Вы действительно хотите удалить запись {selectedStudent.Id}?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    DeleteData(students);
                    MessageBox.Show("Запись удалена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        public void DeleteData(List<PersonLibrary.Student> students)
        {
            PersonLibrary.Student selectedStudent = (PersonLibrary.Student)DataGrid.SelectedItem;
            students.RemoveAll(student => student.Id == selectedStudent.Id);
            AllignId(students);
            Json.WriteJson(students);
            DataGrid.ItemsSource = students;
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            Add formAdd = new Add();
            formAdd.Show();
            Close();

        }
        private void ExitButton(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void EditButton(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
            {
                PersonLibrary.Student selectedStudent = (PersonLibrary.Student)DataGrid.SelectedItem;
                Edit formEdit = new Edit(selectedStudent);
                formEdit.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Выберите строку для редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}