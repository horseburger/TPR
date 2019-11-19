using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Bookstore;
using Bookstore.Entities;

namespace Serializer
{
    public partial class Serializer

    {
        public void SerializeItemBinary(string filename, DataContext item)
        {
            FileStream file = new FileStream(filename, FileMode.Create);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, item);
            file.Close();
        }

        public DataContext DeserializeItemBinary(string filename)
        {
            FileStream s = new FileStream(filename, FileMode.Open);
            IFormatter formatter = new BinaryFormatter();
            return (DataContext) formatter.Deserialize(s);
        }
    }
}