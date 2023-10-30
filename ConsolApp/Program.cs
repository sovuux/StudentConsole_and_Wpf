using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PersonLibrary;
using StudentJson;
using TableCreate;

namespace program;
internal class Program
{
    private static void Main(string[] args)
    {
        PrintMenu();
        System.Environment.Exit(0);
    }
    static void PrintMenu()
    {
        Console.WriteLine("Введите:\n1) Вывести список (изменить запись)\n2) Добавить запись\n3) Удалить запись\n4) Выйти\n");
        var menuIndex = Convert.ToChar(Console.ReadLine());
        Console.Clear();
        switch (menuIndex)
        {
            case '1':
                {
                    ListText();
                    break;
                }
            case '2':
                {
                    ListAdd();
                    break;
                }
            case '3':
                {
                    ListDelete();
                    break;
                }

            case '4':
                {
                    Console.WriteLine("Выполняется выход из программы...");
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                }
            default:
                {
                    Console.WriteLine("Ошибка! Не верный символ!");
                    Console.Clear();
                    PrintMenu();
                    break;
                }
        }
    }
    static void ListText()
    {
        if (Json.ReadJson(out List<Student> Students))
        {
            Console.WindowWidth = 200;
            ListPrint(Students);
            Console.WriteLine();
            ListEdit(Students);
            Json.WriteJson(Students);
            Console.Clear();
            PrintMenu();
        }
        else
        {
            Console.WriteLine("Не удалось найти файл!");
            Console.WriteLine("...");
            Console.WriteLine("Попробуйте заново скачать архив!");
            ListText();
        }
    }
    static void ListPrint(List<Student> Students)
    {
        int index = 1;
        Console.Clear();
        Table.PrintLine();
        Table.PrintRow("Номер", "Имя", "Фамилия", "Отчество", "Город", "Почтовый индекс", "Улица", "Почта", "Телефон", "Курс", "Факультет", "Группа", "Специальность");
        Table.PrintLine();
        foreach (var item in Students)
        {
            Table.PrintRow($"{index}", $"{item.Fio.Name}", $"{item.Fio.Surname}", $"{item.Fio.Patron}", $"{item.Address.City}", $"{item.Address.PstIndex}", $"{item.Address.Street}", $"{item.Contacts.Mail}", $"{item.Contacts.Phone}", $"{item.Curriculum.Course}", $"{item.Curriculum.Faculty}", $"{item.Curriculum.Group}", $"{item.Curriculum.Specialty}");
            index++;
        }
        Table.PrintLine();
    }
    static string SetLibPersonValues(string add)
    {
        Console.WriteLine($"Введите {add}:\n");
        return Console.ReadLine();
    }
    static void ListEdit(List<Student> Students)
    {
        Console.WriteLine("\n\nХотите изменить запись?(1 - да, 2 - выход в главное меню)");
        var questionForEdit = Console.ReadLine();
        if (questionForEdit == "1")
        {
            Console.WriteLine("Введите номер записи, которую хотите изменить:");
            string? idString = Console.ReadLine();
            if (int.TryParse(idString, out int Id) && Id <= Students.Count)
            {
                Id--;
                Console.WriteLine("Что вы хотите изменить:\n1)ФИО\n2)Город\n3)Почтовый индекс\n4)Улицу\n5)Почту\n6)Телефон\n7)Факультет\n8)Курс\n9)Группу\n10)Специальность\n");
                string editIndex = Console.ReadLine();
                switch (editIndex)
                {
                    case "1":
                        Students[Id].Fio.Surname = SetLibPersonValues("Фамилия");
                        Students[Id].Fio.Name = SetLibPersonValues("Имя");
                        Students[Id].Fio.Patron = SetLibPersonValues("Отчество");
                        break;
                    case "2":
                        Students[Id].Address.City = SetLibPersonValues("Город");
                        break;
                    case "3":
                        Students[Id].Address.PstIndex = SetLibPersonValues("Почтовый индекс");
                        break;
                    case "4":
                        Students[Id].Address.Street = SetLibPersonValues("Улица");
                        break;
                    case "5":
                        Students[Id].Contacts.Mail = SetLibPersonValues("Почта");
                        break;
                    case "6":
                        Students[Id].Contacts.Phone = SetLibPersonValues("Телефон");
                        break;
                    case "7":
                        Students[Id].Curriculum.Faculty = SetLibPersonValues("Факультет");
                        break;
                    case "8":
                        Students[Id].Curriculum.Course = SetLibPersonValues("Курс");
                        break;
                    case "9":
                        Students[Id].Curriculum.Group = SetLibPersonValues("Группа");
                        break;
                    case "10":
                        Students[Id].Curriculum.Specialty = SetLibPersonValues("Специальность");
                        break;
                    default:
                        Console.WriteLine("Введен неправильный символ!");
                        Console.ReadKey();
                        ListEdit(Students);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Неверно введено число");
                ListText();
            }
        }
        if (questionForEdit == "2")
        {
            Console.Clear();
            PrintMenu();
        }
        if (questionForEdit != "1" && questionForEdit != "2")
        {
            Console.WriteLine("Вы ввели неправильный символ!");
            ListEdit(Students);
        }
    }

    static void ListAdd()
    {
        if (Json.ReadJson(out List<Student> Persons))
        {
            SetStudents();
            Console.Clear();
            PrintMenu();
        }
        else
        {
            Console.WriteLine("Не удалось найти файл!");
        }
    }
    static void SetStudents()
    {
        if (Json.ReadJson(out List<Student> Students))
        {
            Student Person = new Student();
            Console.WriteLine("Введите ФИО:\n Имя");
            Person.Fio.Name = Console.ReadLine();
            Console.WriteLine(" Фамилия:");
            Person.Fio.Surname = Console.ReadLine();
            Console.WriteLine(" Отчество:");
            Person.Fio.Patron = Console.ReadLine();
            Console.WriteLine("Введите город:");
            Person.Address.City = Console.ReadLine();
            Console.WriteLine("Введите почтовый индекс:");
            Person.Address.PstIndex = Console.ReadLine();
            Console.WriteLine("Введите улицу:");
            Person.Address.Street = Console.ReadLine();
            Console.WriteLine("Введите почту:");
            Person.Contacts.Mail = Console.ReadLine();
            Console.WriteLine("Введите телефон:");
            Person.Contacts.Phone = Console.ReadLine();
            Console.WriteLine("Введите факультет:");
            Person.Curriculum.Faculty = Console.ReadLine();
            Console.WriteLine("Введите курс:");
            Person.Curriculum.Course = Console.ReadLine();
            Console.WriteLine("Введите группу:");
            Person.Curriculum.Group = Console.ReadLine();
            Console.WriteLine("Введите специальность:");
            Person.Curriculum.Specialty = Console.ReadLine();
            Console.Clear();
            Students.Add(Person);
            Json.WriteJson(Students);
        }
        else
        {
            Console.WriteLine("Файл пуст!");
        }
    }
    static void ListDelete()
    {
        if (Json.ReadJson(out List<Student> Students))
        {
            ListPrint(Students);
            Console.WriteLine("\nВведите номер записи, которую необзодимо удалить");
            string idString = Console.ReadLine();
            if (int.TryParse(idString, out int number))
            {
                Console.Clear();
                Students.RemoveAll(id => Students.IndexOf(id) == number - 1);
                Json.WriteJson(Students);
                PrintMenu();
            }
            else
            {
                Console.WriteLine("Вы ввели не число!");
                Console.Clear();
                ListDelete();
            }
        }
        else
        {
            Console.WriteLine("Файл не существует!");
            PrintMenu();
        }
    }

}