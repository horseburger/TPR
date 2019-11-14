using System.IO;
using Bookstore;
using Newtonsoft.Json;

namespace Serializer
{
    public partial class Serializer
    {
        public static void SerializeItemJson(string filename, DataContext context)
        {
            File.WriteAllText(filename, JsonConvert.SerializeObject(context));
        }

        public static string SerializeItemJson(DataContext context)
        {
            return JsonConvert.SerializeObject(context);
        }

        public static DataContext DeserializeItemJson(string obj)
        {
            return JsonConvert.DeserializeObject<DataContext>(obj);
        }

        public static DataContext DeserializeItemJsonFromFile(string filename)
        {
            string json = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<DataContext>(json);
        }
    }
}