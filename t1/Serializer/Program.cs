using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Bookstore;
using Bookstore.Objects;

namespace Serializer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string filename = "abc";
            IFormatter formatter = new BinaryFormatter();
            Program.SerializeItem(filename, formatter);
            DataContext c = Program.DeserializeItem(filename, formatter);
            Console.WriteLine(c.Clients[0].Name + ' ' + c.Clients[0].Surname);
        }

        public static void SerializeItem(string filename, IFormatter formatter)
        {
            DataContext context = new DataContext();
            context.Clients.Add(new Client("Jan", "kowalski"));
            FileStream file = new FileStream(filename, FileMode.Create);
            formatter.Serialize(file, context);
            file.Close();
        }

        public static DataContext DeserializeItem(string filename, IFormatter formatter)
        {
            FileStream s = new FileStream(filename, FileMode.Open);
            return (DataContext) formatter.Deserialize(s);
        }
    }
}