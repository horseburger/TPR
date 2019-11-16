using System.IO;
using Bookstore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Serializer
{
    public partial class Serializer
    {
        JsonSerializerSettings settings;
        public Serializer()
        {
            settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All,
                MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore

            };
        }

        public void SerializeItemJson(string filename, DataContext context)
        {
            File.WriteAllText(filename, JsonConvert.SerializeObject(context, settings));
        }

        public string SerializeItemJson(DataContext context)
        {
            return JsonConvert.SerializeObject(context, settings);
        }

        public DataContext DeserializeItemJson(string obj)
        {
            return JsonConvert.DeserializeObject<DataContext>(obj, settings);
        }

        public DataContext DeserializeItemJsonFromFile(string filename)
        {
            string json = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<DataContext>(json, settings);
        }

    }
}