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
        public static void SerializeItemBinary(string filename, IFormatter formatter, DataContext item)
        {
            FileStream file = new FileStream(filename, FileMode.Create);
            formatter.Serialize(file, item);
            file.Close();
        }

        public static DataContext DeserializeItemBinary(string filename, IFormatter formatter)
        {
            FileStream s = new FileStream(filename, FileMode.Open);
            return (DataContext) formatter.Deserialize(s);
        }
    }
}