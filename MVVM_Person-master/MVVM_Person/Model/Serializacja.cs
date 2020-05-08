using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace MVVM_Person.Model
{
    //zapisuje obiekty do pliku xml za pomocą serializacji
    public static class Serializacja_wczytaj_zapisz
    {
        public static void RecordData(string Path, List<Person> PersonsList)
        {
            XmlSerializer sx = new XmlSerializer(typeof(List<Person>));
            using (TextWriter tw = new StreamWriter(Path)) sx.Serialize(tw, PersonsList);
        }
        //wczytuje liste obiektow z pliku za pomoca serializacji
        public static List<Person> LoadData(string Path)
        {
            List<Person> persons = new List<Person>();
            XmlSerializer sx = new XmlSerializer(typeof(List<Person>));

            using (TextReader tw = new StreamReader(Path))
            return sx.Deserialize(tw) as List<Person>;
        }
    }
}
