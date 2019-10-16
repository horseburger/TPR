using System;

namespace part_one
{
    public class Wykaz
    {
        private string name;
        private string surname;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }



        public Wykaz(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
    }
}