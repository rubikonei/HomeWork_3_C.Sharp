using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataBase
{
    class BinReaderWriter
    {
        public void Write(List<Employee> list, string path)
        {
            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fsbin = new FileStream(path, FileMode.Create))
            {
                bf.Serialize(fsbin, list);
            }
        }

        public List<Employee> Read(string path)
        {
            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fsbin = new FileStream(path, FileMode.OpenOrCreate))
            {
                return (List<Employee>)bf.Deserialize(fsbin);
            }
        }
    }
}
