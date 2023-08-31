using System;
using System.Net;

namespace PersonLibrary
{
    public class Student
    {
        public int? Id { get; set; }
        public LibFio? Fio { get; set; }
        public LibUniInfo? Curriculum { get; set; }
        public LibAdress? Address { get; set; }
        public LibContacts? Contacts { get; set; }
        public Student()
        {
            Fio = new LibFio();
            Curriculum = new LibUniInfo();
            Address = new LibAdress();
            Contacts = new LibContacts();
        }
    };
}