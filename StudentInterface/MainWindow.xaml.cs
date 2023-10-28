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
            Json.ReadJson(out List<PersonLibrary.Student> Students);
            DataGrid.ItemsSource = Students;
        }
        public void AllignId(List<PersonLibrary.Student> Students)
        {
            int[] stringID = new int[Students.Count];
            for (int index = 0; index < Students.Count; index++)
            {
                stringID[index] = index;
                Students[index].Id = index + 1;
            }
        }
        void Delete_Click(object sender, RoutedEventArgs e)
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
            Json.ReadJson(out List<PersonLibrary.Student> Students);
            PersonLibrary.Student selectedStudent = (PersonLibrary.Student)DataGrid.SelectedItem;
            if (Students != null)
            {
                MessageBoxResult result = MessageBox.Show($"Вы действительно хотите удалить запись {selectedStudent.Id}?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    DeleteData(Students);
                    MessageBox.Show("Запись удалена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        public void DeleteData(List<PersonLibrary.Student> Students)
        {
            PersonLibrary.Student selectedStudent = (PersonLibrary.Student)DataGrid.SelectedItem;
            Students.RemoveAll(Student => Student.Id == selectedStudent.Id);
            AllignId(Students);
            Json.WriteJson(Students);
            DataGrid.ItemsSource = Students;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Add form_Add = new Add();
            form_Add.Show();
            Close();

        }
        private void Exit_but(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
            {
                PersonLibrary.Student selectedStudent = (PersonLibrary.Student)DataGrid.SelectedItem;
                Edit form_Edit = new Edit(selectedStudent);
                form_Edit.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Выберите строку для редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}