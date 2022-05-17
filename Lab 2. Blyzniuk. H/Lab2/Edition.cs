using System;

namespace Lab2
{
    public class Edition
    {
        protected string name;
        protected DateTime date;
        protected int circulation;

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Circulation { get; set; }


        public Edition(string name, DateTime date, int circulation)
        {
            Name = name;
            Date = date;
            Circulation = circulation;
        }


        public Edition() : this(string.Empty, DateTime.Today, 0) { }


        public virtual object DeepCopy()
        {
            return MemberwiseClone();
        }


        public override bool Equals(object obj)
        {
            var edition = obj as Edition;
            return Name == edition?.Name &&
                Date == edition?.Date &&
                Circulation == edition?.Circulation;
        }


        public static bool operator ==(Edition edition1, Edition edition2)
        {
            return edition1.Equals(edition2);
        }


        public static bool operator !=(Edition edition1, Edition edition2)
        {
            return !edition1.Equals(edition2);
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Date, Circulation);
        }


        public override string ToString() =>
                $"Name: {Name}\n" +
                $"Date: {Date}\n" +
                $"Circulation: {Circulation}";
    }
}
