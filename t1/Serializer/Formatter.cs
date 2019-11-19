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
            // todo 'implement deserialize' 
            return null;
        }

        public void Serialize(Stream serializationStream, object graph)
        {
            //todo 'implement serialize''
        }

        public SerializationBinder Binder { get; set; }
        public StreamingContext Context { get; set; }
        public ISurrogateSelector SurrogateSelector { get; set; }
    }
}