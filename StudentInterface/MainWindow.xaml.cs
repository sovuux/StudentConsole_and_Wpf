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
            Json.ReadJson(out List<PersonLibrary.Student> Students);
            DataGrid.ItemsSource = Students;

        }
       

        public void AllignId(List<PersonLibrary.Student> Students)
        {
            int[] capId = new int[Students.Count];
            for (int i = 0; i < Students.Count; i++)
            {
                capId[i] = i;
                Students[i].Id = i + 1;
            }
        }
        void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
            {
                Json.ReadJson(out List<PersonLibrary.Student> Students);
                PersonLibrary.Student selectedStudent = (PersonLibrary.Student)DataGrid.SelectedItem;
                if (Students != null)
                {
                    DeleteData(Students);
                    MessageBox.Show("Запись удалена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите строку(и) для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }
        
        public void DeleteData(List<PersonLibrary.Student> Students)
        {
            PersonLibrary.Student selectedStudent = (PersonLibrary.Student)DataGrid.SelectedItem;
            Students.RemoveAll(student => student.Id == selectedStudent.Id);
            AllignId(Students);
            Json.WriteJson(Students);
            DataGrid.ItemsSource = Students;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Add form2 = new Add();
            form2.Show();
            Close();

        }
        private void but_Ex(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LineId.Text))
            {
                int SelectedId = int.Parse(LineId.Text);
                Json.ReadJson(out List<PersonLibrary.Student> Students);
                PersonLibrary.Student SelectedStudent = Students.FirstOrDefault(student => student.Id == SelectedId);
                if (SelectedStudent != null)
                {
                    Edit form3 = new Edit(SelectedStudent);
                    form3.Show();
                    Close();
                }
            }
        }
    }
}