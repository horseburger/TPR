using Newtonsoft.Json;
using part_one;

namespace part_five
{
    public class DataFillerJSON : DataFiller
    {
        public void Fill(DataContext context)
        {
            string json = System.IO.File.ReadAllText("./inputDataFiller.json");
            context = JsonConvert.DeserializeObject<DataContext>(json);
        }
    }
}