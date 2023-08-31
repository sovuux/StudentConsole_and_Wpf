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
        var mc = Convert.ToChar(Console.ReadLine());
        Console.Clear();
        switch (mc)
        {
            case '1':
                {
                    ListText();
                    break;
                }
            case '2':
                {
                    Add();
                    break;
                }
            case '3':
                {
                    Delete();
                    break;
                }

            case '4':
                {
                    Console.WriteLine("Выполняется выход из программы...");
                    Thread.Sleep(850);
                    Console.Clear();
                    System.Environment.Exit(0);
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
        if (Json.ReadJson(out List<Student> Persons))
        {
            Console.WindowWidth = 200;
            ListPrint(Persons);
            Console.WriteLine();
            ListEdit(Persons);
            Json.WriteJson(Persons);
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
    static void ListPrint(List<Student> Persons)
    {
        int i = 1;
        Console.Clear();
        Table.PrintLine();
        Table.PrintRow("Номер", "Имя", "Фамилия", "Отчество", "Город", "Почтовый индекс", "Улица", "Почта", "Телефон", "Курс", "Факультет", "Группа", "Специальность");
        Table.PrintLine();
        foreach (var item in Persons)
        {
            Table.PrintRow($"{i}", $"{item.Fio.Name}", $"{item.Fio.Surname}", $"{item.Fio.Patron}", $"{item.Address.City}", $"{item.Address.PstIndex}", $"{item.Address.Street}", $"{item.Contacts.Mail}", $"{item.Contacts.Phone}", $"{item.Curriculum.Course}", $"{item.Curriculum.Faculty}", $"{item.Curriculum.Group}", $"{item.Curriculum.Specialty}");
            i++;
        }
        Table.PrintLine();
    }
    static string SetLibPersonValues(string add)
    {
        Console.WriteLine($"Введите {add}:\n");
        return Console.ReadLine();
    }
    static void ListEdit(List<Student> persons)
    {
        Console.WriteLine("\n\nХотите изменить запись?(1 - да, 2 - выход в главное меню)");
        var editor = Console.ReadLine();
        if (editor == "1")
        {
            Console.WriteLine("Введите номер записи, которую хотите изменить:");
            string? IdString = Console.ReadLine();
            if (int.TryParse(IdString, out int Id) && Id <= persons.Count)
            {
                Id--;
                Console.WriteLine("Что вы хотите изменить:\n1)ФИО\n2)Город\n3)Почтовый индекс\n4)Улицу\n5)Почту\n6)Телефон\n7)Факультет\n8)Курс\n9)Группу\n10)Специальность\n");
                string t = Console.ReadLine();
                switch (t)
                {
                    case "1":
                        persons[Id].Fio.Surname = SetLibPersonValues("Фамилия");
                        persons[Id].Fio.Name = SetLibPersonValues("Имя");
                        persons[Id].Fio.Patron = SetLibPersonValues("Отчество");
                        break;
                    case "2":
                        persons[Id].Address.City = SetLibPersonValues("Город");
                        break;
                    case "3":
                        persons[Id].Address.PstIndex = SetLibPersonValues("Почтовый индекс");
                        break;
                    case "4":
                        persons[Id].Address.Street = SetLibPersonValues("Улица");
                        break;
                    case "5":
                        persons[Id].Contacts.Mail = SetLibPersonValues("Почта");
                        break;
                    case "6":
                        persons[Id].Contacts.Phone = SetLibPersonValues("Телефон");
                        break;
                    case "7":
                        persons[Id].Curriculum.Faculty = SetLibPersonValues("Факультет");
                        break;
                    case "8":
                        persons[Id].Curriculum.Course = SetLibPersonValues("Курс");
                        break;
                    case "9":
                        persons[Id].Curriculum.Group = SetLibPersonValues("Группа");
                        break;
                    case "10":
                        persons[Id].Curriculum.Specialty = SetLibPersonValues("Специальность");
                        break;
                    default:
                        Console.WriteLine("Введен неправильный символ!");
                        Console.ReadKey();
                        ListEdit(persons);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Неверно введено число");
                ListText();
            }
        }
        if (editor == "2")
        {
            Console.Clear();
            PrintMenu();
        }
        if (editor != "1" && editor != "2")
        {
            Console.WriteLine("Вы ввели неправильный символ!");
            ListEdit(persons);
        }
    }

    static void Add()
    {
        if (Json.ReadJson(out List<Student> Persons))
        {
            SetPerson();
            Console.Clear();
            PrintMenu();
        }
        else
        {
            Console.WriteLine("Не удалось найти файл!");
        }
    }
    static void SetPerson()
    {
        if (Json.ReadJson(out List<Student> Persons))
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
            Persons.Add(Person);
            Json.WriteJson(Persons);
        }
        else
        {
            Console.WriteLine("Файл пуст!");
        }
    }
    static void Delete()
    {
        if (Json.ReadJson(out List<Student> Persons))
        {
            ListPrint(Persons);
            Console.WriteLine("\nВведите номер записи, которую необзодимо удалить");
            string numberString = Console.ReadLine();
            if (int.TryParse(numberString, out int number))
            {
                Console.Clear();
                Persons.RemoveAll(x => Persons.IndexOf(x) == number - 1);
                Json.WriteJson(Persons);
                PrintMenu();
            }
            else
            {
                Console.WriteLine("Вы ввели не число!");
                Console.Clear();
                Delete();
            }
        }
        else
        {
            Console.WriteLine("Файл не существует!");
            PrintMenu();
        }
    }

}