namespace Lab6
{
    class Book : IHasName
    {
        public string Name { get; }

        public Book(string name)
        {
            this.Name = name;
        }
    }
}
