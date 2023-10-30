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
                    AddList();
                    break;
                }
            case '3':
                {
                    DeleteList();
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
        if (Json.ReadJson(out List<Student> students))
        {
            Console.WindowWidth = 200;
            PrintList(students);
            Console.WriteLine();
            EditList(students);
            Json.WriteJson(students);
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
    static void PrintList(List<Student> students)
    {
        int index = 1;
        Console.Clear();
        Table.PrintLine();
        Table.PrintRow("Номер", "Имя", "Фамилия", "Отчество", "Город", "Почтовый индекс", "Улица", "Почта", "Телефон", "Курс", "Факультет", "Группа", "Специальность");
        Table.PrintLine();
        foreach (var item in students)
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
    static void EditList(List<Student> students)
    {
        Console.WriteLine("\n\nХотите изменить запись?(1 - да, 2 - выход в главное меню)");
        var questionForEdit = Console.ReadLine();
        if (questionForEdit == "1")
        {
            Console.WriteLine("Введите номер записи, которую хотите изменить:");
            string? idString = Console.ReadLine();
            if (int.TryParse(idString, out int Id) && Id <= students.Count)
            {
                Id--;
                Console.WriteLine("Что вы хотите изменить:\n1)ФИО\n2)Город\n3)Почтовый индекс\n4)Улицу\n5)Почту\n6)Телефон\n7)Факультет\n8)Курс\n9)Группу\n10)Специальность\n");
                string editIndex = Console.ReadLine();
                switch (editIndex)
                {
                    case "1":
                        students[Id].Fio.Surname = SetLibPersonValues("Фамилия");
                        students[Id].Fio.Name = SetLibPersonValues("Имя");
                        students[Id].Fio.Patron = SetLibPersonValues("Отчество");
                        break;
                    case "2":
                        students[Id].Address.City = SetLibPersonValues("Город");
                        break;
                    case "3":
                        students[Id].Address.PstIndex = SetLibPersonValues("Почтовый индекс");
                        break;
                    case "4":
                        students[Id].Address.Street = SetLibPersonValues("Улица");
                        break;
                    case "5":
                        students[Id].Contacts.Mail = SetLibPersonValues("Почта");
                        break;
                    case "6":
                        students[Id].Contacts.Phone = SetLibPersonValues("Телефон");
                        break;
                    case "7":
                        students[Id].Curriculum.Faculty = SetLibPersonValues("Факультет");
                        break;
                    case "8":
                        students[Id].Curriculum.Course = SetLibPersonValues("Курс");
                        break;
                    case "9":
                        students[Id].Curriculum.Group = SetLibPersonValues("Группа");
                        break;
                    case "10":
                        students[Id].Curriculum.Specialty = SetLibPersonValues("Специальность");
                        break;
                    default:
                        Console.WriteLine("Введен неправильный символ!");
                        Console.ReadKey();
                        EditList(students);
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
            EditList(students);
        }
    }

    static void AddList()
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
        if (Json.ReadJson(out List<Student> students))
        {
            Student student = new Student();
            Console.WriteLine("Введите ФИО:\n Имя");
            student.Fio.Name = Console.ReadLine();
            Console.WriteLine(" Фамилия:");
            student.Fio.Surname = Console.ReadLine();
            Console.WriteLine(" Отчество:");
            student.Fio.Patron = Console.ReadLine();
            Console.WriteLine("Введите город:");
            student.Address.City = Console.ReadLine();
            Console.WriteLine("Введите почтовый индекс:");
            student.Address.PstIndex = Console.ReadLine();
            Console.WriteLine("Введите улицу:");
            student.Address.Street = Console.ReadLine();
            Console.WriteLine("Введите почту:");
            student.Contacts.Mail = Console.ReadLine();
            Console.WriteLine("Введите телефон:");
            student.Contacts.Phone = Console.ReadLine();
            Console.WriteLine("Введите факультет:");
            student.Curriculum.Faculty = Console.ReadLine();
            Console.WriteLine("Введите курс:");
            student.Curriculum.Course = Console.ReadLine();
            Console.WriteLine("Введите группу:");
            student.Curriculum.Group = Console.ReadLine();
            Console.WriteLine("Введите специальность:");
            student.Curriculum.Specialty = Console.ReadLine();
            Console.Clear();
            students.Add(student);
            Json.WriteJson(students);
        }
        else
        {
            Console.WriteLine("Файл пуст!");
        }
    }
    static void DeleteList()
    {
        if (Json.ReadJson(out List<Student> students))
        {
            PrintList(students);
            Console.WriteLine("\nВведите номер записи, которую необходимо удалить");
            string idString = Console.ReadLine();
            if (int.TryParse(idString, out int number))
            {
                Console.Clear();
                students.RemoveAll(id => students.IndexOf(id) == number - 1);
                Json.WriteJson(students);
                PrintMenu();
            }
            else
            {
                Console.WriteLine("Вы ввели не число!");
                Console.Clear();
                DeleteList();
            }
        }
        else
        {
            Console.WriteLine("Файл не существует!");
            PrintMenu();
        }
    }

}