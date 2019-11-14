using System.IO;
using Bookstore;
using Newtonsoft.Json;

namespace Serializer
{
    public partial class Serializer
    {
        public static void SerializeItemJSON(string filename, DataContext context)
        {
            File.WriteAllText(filename, JsonConvert.SerializeObject(context));
        }

        public static string SerializeItemJSON(DataContext context)
        {
            return JsonConvert.SerializeObject(context);
        }

        public static DataContext DeserializeItemJSON(string obj)
        {
            return JsonConvert.DeserializeObject<DataContext>(obj);
        }

        public static DataContext DeserializeItemJSONFromFile(string filename)
        {
            string json = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<DataContext>(json);
        }
    }
}