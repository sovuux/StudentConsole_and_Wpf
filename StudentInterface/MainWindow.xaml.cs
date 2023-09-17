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
using PersonLibrary;
using Student.Interface;
using StudentJson;

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
            Json.ReadJson(out List<PersonLibrary.Student> Persons);
            AllignId(Persons);
            DataGrid.ItemsSource = Persons;
        }

       
        public void AllignId(List<PersonLibrary.Student> Persons) 
        {
            int[] capId = new int[Persons.Count];
            for (int i = 0; i < Persons.Count; i++) 
            {
                capId[i] = i;
                Persons[i].Id = i + 1;
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Json.ReadJson(out List<PersonLibrary.Student> Persons);
            AllignId(Persons);
            if (int.TryParse(LineId.Text, out int number))
            {
                Persons.RemoveAll(x => Persons.IndexOf(x) == Convert.ToInt32(LineId.Text) - 1);
            }
            else
            {
                LineId.Text = string.Empty;
                MessageBox.Show("Введите номер записи", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            AllignId(Persons);
            Json.WriteJson(Persons);
            DataGrid.ItemsSource = Persons;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Add form2 = new Add();
            form2.Show();
            this.Close();
        }
    }
    
}   
