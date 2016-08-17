using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DataBase
{
    class XmlReaderWriter
    {
        public void Write(List<Employee> list, string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Employee>));

            using (FileStream fsxml = new FileStream(path, FileMode.Create))
            {
                xs.Serialize(fsxml, list);
            }
        }

        public List<Employee> Read(string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Employee>));

            using (FileStream fsxml = new FileStream(path, FileMode.OpenOrCreate))
            {
                return (List<Employee>)xs.Deserialize(fsxml);
            }
        }
    }
}
