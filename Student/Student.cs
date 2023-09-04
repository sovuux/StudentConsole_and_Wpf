using System;
using System.Net;

namespace PersonLibrary
{
    public class Student
    {
        public int? Id { get; set; }
        public StudentFio? Fio { get; set; }
        public StudentUniInfo? Curriculum { get; set; }
        public StudentAdress? Address { get; set; }
        public StudentContacts? Contacts { get; set; }
        public Student()
        {
            Fio = new StudentFio();
            Curriculum = new StudentUniInfo();
            Address = new StudentAdress();
            Contacts = new StudentContacts();
        }
    };
}