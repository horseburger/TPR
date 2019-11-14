using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Bookstore;
using Bookstore.Objects;

namespace Serializer
{
    public class Serializer : IFormatter

    {
    public static void SerializeItem(string filename, IFormatter formatter, DataContext item)
    {
        FileStream file = new FileStream(filename, FileMode.Create);
        formatter.Serialize(file, item);
        file.Close();
    }

    public static DataContext DeserializeItem(string filename, IFormatter formatter)
    {
        FileStream s = new FileStream(filename, FileMode.Open);
        return (DataContext) formatter.Deserialize(s);
    }

    public object Deserialize(Stream serializationStream)
    {
        if (serializationStream == null)
        {
            throw new ArgumentNullException("Serialization stream null");
        }
        
        IFormatter formatter = new BinaryFormatter();
        return formatter.Deserialize(serializationStream);
    }

    public void Serialize(Stream serializationStream, object graph)
    {
        if (serializationStream == null)
        {
            throw new ArgumentNullException("Serialization stream null");
        }

        if (graph == null)
        {
            throw new ArgumentNullException("Graph null");
        }

        if (!serializationStream.CanWrite)
        {
            throw new ArgumentException("Stream can't write");
        }
        
        IFormatter formatter = new BinaryFormatter();
        formatter.Serialize(serializationStream, graph);
    }

    public SerializationBinder Binder { get; set; }
    public StreamingContext Context { get; set; }
    public ISurrogateSelector SurrogateSelector { get; set; }
    }
}