using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serializer
{
    public partial class Serializer : IFormatter
    {
        public object Deserialize(Stream serializationStream)
        {
            if (serializationStream == null)
            {
                throw new ArgumentNullException(nameof(serializationStream));
            }
        
            IFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(serializationStream);
        }

        public void Serialize(Stream serializationStream, object graph)
        {
            if (serializationStream == null)
            {
                throw new ArgumentNullException(nameof(serializationStream));
            }

            if (graph == null)
            {
                throw new ArgumentNullException(nameof(graph));
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