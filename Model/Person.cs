namespace Model
{
    public class Person
    {
        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Person()
        {
        }

        public override string ToString()
        {
            return "Pessoa: " + "\n" + "Id: " + Id + "\n" + "Nome: " + Name + "\n";
        }

        public void alterarNome(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}