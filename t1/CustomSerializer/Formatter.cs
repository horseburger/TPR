using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Bookstore;
using Bookstore.Entities;

namespace CustomSerializer
{
    public partial class Serializer : ISerializer
    {

        private Dictionary<int, Object> _dict { get; set; }
        private string _serializedData { get; set; }
        public List<string[]> DeserializedData { get; set; }
        private char separator = ';';
        
        public void Serialize(string filename, DataContext context)
        {
            ObjectIDGenerator idGen = new ObjectIDGenerator();
            _serializedData = "";
            foreach(Client c in context.Clients)
            {
                _serializedData += c.Serialization(idGen) + "\n";
            }

            foreach (KeyValuePair<int, Book> book in context.Books)
            {
                _serializedData += book.Value.Serialization(idGen) + book.Key + separator + "\n";
            }
            
            foreach (Status s in context.Statuses)
            {
                _serializedData += s.Serialization(idGen) + "\n";
            }
            
            foreach (Event e in context.Events)
            {
                _serializedData += e.Serialization(idGen) + "\n";
            }


            FileStream fs = new FileStream(filename, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(_serializedData);
            sw.Close();
            fs.Close();

        }

        public DataContext Deserialize(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            char[] sep = {separator};
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                DeserializedData.Add(line.Split(sep));
            }
            fs.Close();
            sr.Close();

            return ConstructObjects();
        }

        private DataContext ConstructObjects()
        {
            DataContext result = new DataContext();
            string type = "";
            Dictionary<int, int> eventIds = new Dictionary<int, int>();
            foreach (string[] data in this.DeserializedData)
            {
                try
                {
                    type = data[0];
                }
                catch (IndexOutOfRangeException e)
                {
                    type = "";
                    Console.WriteLine(e.Message);
                }
                

                switch (type)
                {
                    case "Bookstore.Entities.Client":
                        Client c = new Client();
                        c.Deserialization(data, _dict);
                        result.Clients.Add(c);
                        if (!_dict.ContainsKey(int.Parse(data[1])))
                        {
                            _dict.Add(int.Parse(data[1]), c);
                        }

                        break;
                    case "Bookstore.Entities.Book":
                        Book b = new Book();
                        b.Deserialization(data, _dict);
                        for (int i = 4; i < data.Length - 1; i++)
                        {
                            if (!eventIds.ContainsKey(b.Id))
                            {
                                eventIds.Add(int.Parse(data[i]), int.Parse(data[1]));
                            }
                        }
                        result.Books.Add(int.Parse(data[data.Length - 2]), b);
                        if (!_dict.ContainsKey(int.Parse(data[1])))
                        {
                            _dict.Add(int.Parse(data[1]), b);
                        }

                        break;
                    case "Bookstore.Entities.Status":
                        Status s = new Status();
                        s.Deserialization(data, _dict);
                        result.Statuses.Add(s);
                        if (!_dict.ContainsKey(int.Parse(data[1])))
                        {
                            _dict.Add(int.Parse(data[1]), s);
                        }

                        break;
                    case "Bookstore.Entities.Borrow":
                        Borrow bor = new Borrow();
                        bor.Deserialization(data, _dict);
                        result.Events.Add(bor);
                        if (!_dict.ContainsKey(int.Parse(data[1])))
                        {
                            _dict.Add(int.Parse(data[1]), bor);
                        }

                        foreach (KeyValuePair<int, int> i  in eventIds)
                        {
                            if(i.Key == int.Parse(data[1]))
                            {
                                Book book1 = (Book) _dict[i.Value];
                                book1.Events.Add(bor);
                            }
                        }
                        break;
                    case "Bookstore.Entities.Purchase":
                        Purchase p = new Purchase();
                        p.Deserialization(data, _dict);
                        result.Events.Add(p);
                        if (!_dict.ContainsKey(int.Parse(data[1])))
                        {
                            _dict.Add(int.Parse(data[1]), p);
                        }

                        foreach (KeyValuePair<int, int> i in eventIds)
                        {
                            if (i.Key == int.Parse(data[1]))
                            {
                                Book book2 = (Book) _dict[i.Value];
                                book2.Events.Add(p);
                            }
                        }
                        break;
                }
            }

            return result;
        }
    }
}