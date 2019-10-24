namespace Bookstore.Objects
{
    public class Klient
    {
        private string name;
        private string surname;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }



        public Klient(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
    }
}