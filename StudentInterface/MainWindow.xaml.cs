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
            int[] StringID = new int[Students.Count];
            for (int Index = 0; Index < Students.Count; Index++)
            {
                StringID[Index] = Index;
                Students[Index].Id = Index + 1;
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
            Json.ReadJson(out List<PersonLibrary.Student> Students);
            PersonLibrary.Student SelectedStudent = (PersonLibrary.Student)DataGrid.SelectedItem;
            if (Students != null)
            {
                MessageBoxResult Result = MessageBox.Show($"Вы действительно хотите удалить запись {SelectedStudent.Id}?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (Result == MessageBoxResult.Yes)
                {
                    DeleteData(Students);
                    MessageBox.Show("Запись удалена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        public void DeleteData(List<PersonLibrary.Student> Students)
        {
            PersonLibrary.Student SelectedStudent = (PersonLibrary.Student)DataGrid.SelectedItem;
            Students.RemoveAll(Student => Student.Id == SelectedStudent.Id);
            AllignId(Students);
            Json.WriteJson(Students);
            DataGrid.ItemsSource = Students;
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            Add FormAdd = new Add();
            FormAdd.Show();
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
                PersonLibrary.Student SelectedStudent = (PersonLibrary.Student)DataGrid.SelectedItem;
                Edit FormEdit = new Edit(SelectedStudent);
                FormEdit.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Выберите строку для редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}