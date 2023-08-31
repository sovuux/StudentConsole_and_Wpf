using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using PersonLibrary;

namespace StudentJson
{
    public class Json
    {
        private static string pathTo = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "ListText.json");

        static public bool ReadJson(out List<Student> Persons)
        {
            string flag = File.ReadAllText(pathTo).Trim();
            if (flag != "")
            {
                Persons = JsonSerializer.Deserialize<List<Student>>(File.ReadAllText(pathTo));
                return true;
            }
            else
            {
                Persons = null;
                return false;
            }
        }
        static public void WriteJson(List<Student> Persons)
        {
            string jsonString = JsonSerializer.Serialize(Persons, Options());
            File.WriteAllText(pathTo, jsonString);
        }
        static JsonSerializerOptions Options()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            return options;
        }
    }
}
