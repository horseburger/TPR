using System;

namespace Bookstore.Objects
{
    [Serializable]
    public class Client
    {
        private string name;
        private string surname;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }



        public Client(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
    }
}