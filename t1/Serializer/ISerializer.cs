using Bookstore;

namespace Serializer
{
    public interface ISerializer
    {
        void Serialize(string filename, DataContext context);
        DataContext Deserialize(string filename);
    }
}