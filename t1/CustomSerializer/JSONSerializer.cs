using System.Collections.Generic;
using System.IO;
using Bookstore;
using Newtonsoft.Json;

namespace CustomSerializer
{
    public partial class Serializer
    {
        JsonSerializerSettings settings;
        public Serializer()
        {
            settings = new JsonSerializerSettings
                {
                TypeNameHandling = TypeNameHandling.Auto,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };
            this._dict = new Dictionary<int, object>();
            this.DeserializedData = new List<string[]>();
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