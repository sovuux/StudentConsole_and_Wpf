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
            AllignId(Students);
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
            if (LineId.Text == "" && DataGrid.SelectedItem == null)
            {
                MessageBox.Show("Введите ID записи или выберите строку(и) для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else { 
                Json.ReadJson(out List<PersonLibrary.Student> Students);
                if (LineId.Text != null) 
                { 
                AllignId(Students);
                if (int.TryParse(LineId.Text, out int number))
                {
                    Students.RemoveAll(x => Students.IndexOf(x) == Convert.ToInt32(LineId.Text) - 1);
                    AllignId(Students);
                    Json.WriteJson(Students);
                    DataGrid.ItemsSource = Students;
                    LineId.Text = null;
                    MessageBox.Show("Запись удалена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                }
                if (LineId.Text ==  "") 
                {
                    if (DataGrid.SelectedItem != null)
                    {
                        PersonLibrary.Student selectedStudent = (PersonLibrary.Student)DataGrid.SelectedItem;
                        if (Students != null)
                        {
                            Students.RemoveAll(student => student.Id == selectedStudent.Id);
                            AllignId(Students);
                            Json.WriteJson(Students);
                            DataGrid.ItemsSource = Students;
                            MessageBox.Show("Запись удалена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
            }

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Add form2 = new Add();
            form2.Show();
            this.Close();

        }
        private void Button_KeyDown(object sender, KeyEventArgs e)
        {   
            if (e.Key == Key.Delete)
            {
                if (DataGrid.SelectedItem != null)
                {
                    PersonLibrary.Student selectedStudent = (PersonLibrary.Student)DataGrid.SelectedItem;
                    Json.ReadJson(out List<PersonLibrary.Student> Students);
                    if (Students != null)
                    {
                        Students.RemoveAll(student => student.Id == selectedStudent.Id);
                        Json.WriteJson(Students);
                        DataGrid.ItemsSource = Students;
                        MessageBox.Show("Запись удалена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            
        }

        private void but_Ex(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    
}   
