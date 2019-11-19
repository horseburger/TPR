using Bookstore;

namespace CustomSerializer
{
    public interface ISerializer
    {
        void Serialize(string filename, DataContext context);
        DataContext Deserialize(string filename);
    }
}