using System;
using System.Collections.Generic;

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

        public override bool Equals(object obj)
        {
            return obj is Client client &&
                   Name == client.Name &&
                   Surname == client.Surname;
        }

        public override int GetHashCode()
        {
            var hashCode = 305228700;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname);
            return hashCode;
        }
        public override string ToString()
        {
            return Name + ":" + Surname;
        }
    }
}