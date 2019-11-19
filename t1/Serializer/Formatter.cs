using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Bookstore;

namespace Serializer
{
    public partial class Serializer : ISerializer
    {

        public SerializationBinder Binder { get; set; }
        public StreamingContext Context { get; set; }
        public ISurrogateSelector SurrogateSelector { get; set; }
        public void Serialize(string filename, DataContext context)
        {
            throw new NotImplementedException();
        }

        public DataContext Deserialize(string filename)
        {
            throw new NotImplementedException();
        }
    }
}