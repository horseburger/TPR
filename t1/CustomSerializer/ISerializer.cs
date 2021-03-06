using Bookstore;

namespace CustomSerializer
{
    public interface ISerializer
    {
        void SerializeItemBinary(string filename, DataContext item);
        DataContext DeserializeItemBinary(string filename);
        void SerializeItemJson(string filename, DataContext context);
        string SerializeItemJson(DataContext context);
        DataContext DeserializeItemJson(string obj);
        DataContext DeserializeItemJsonFromFile(string filename);
    }
}