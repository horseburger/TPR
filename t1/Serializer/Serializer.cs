using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Bookstore;
using Bookstore.Objects;

namespace Serializer
{
    public partial class Serializer

    {
        public void SerializeItemBinary(string filename, DataContext item)
        {
            FileStream file = new FileStream(filename, FileMode.Create);
            Serialize(file, item);
            file.Close();
        }

        public DataContext DeserializeItemBinary(string filename)
        {
            FileStream s = new FileStream(filename, FileMode.Open);
            return (DataContext) Deserialize(s);
        }
    }
}