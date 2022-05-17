namespace Lab2
{
    public class Article : IRateAndCopy
    {
        public Person Person { get; set; }

        public string ArticleName { get; set; }

        public double Rate { get; set; }

        public Article(Person person, string articleName, double rate)
        {
            Person = person;
            ArticleName = articleName;
            Rate = rate;
        }

        public Article()
        {
            Person = null;
            ArticleName = string.Empty;
            Rate = 0.0f;
        }

        public override string ToString() =>
            $"Autor: {Person}, Article name: {ArticleName}, rate: {Rate}";

        // lab2

        public object DeepCopy()
        {
            return MemberwiseClone();
        }

        public double Rating => Rate;

        public bool this[double value]
        {
            get => Rating > value;
        }

        public bool this[string value]
        {
            get => ArticleName.Contains(value);
        }

    }
}
