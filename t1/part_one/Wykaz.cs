using System;

namespace part_one
{
    public class Wykaz
    {
        private string name, surname;

        public string Name => name;
        public string Surname => surname;

        public Wykaz(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }
    }
}