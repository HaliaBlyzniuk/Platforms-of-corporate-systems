using System;
using System.Collections.Generic;

namespace Lab1
{
    class Edition : IComparable, IComparer<Edition>
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }

        private int _circulation;
        public int Circulation
        {
            get => _circulation;
            set
            {
                if (value < 0)
                {
                    throw new Exception("EditionCirculation must be more then 0");
                }

                _circulation = value;
            }
        }

        public Edition() : this("Edition name", DateTime.Today, 1) { }

        public Edition(string editionName, DateTime editionDate, int editionCirculation)
        {
            Name = editionName;
            Date = editionDate;
            Circulation = editionCirculation;
        }

        public virtual object DeepCopy() => MemberwiseClone();

        public override string ToString() => $"Name: {Name}, Date: {Date}, Circulation: {Circulation}";

        public override bool Equals(object obj)
        {
            var edition = obj as Edition;
            return edition != null &&
                   Name == edition.Name &&
                   Date == edition.Date &&
                   Circulation == edition.Circulation;
        }

        public override int GetHashCode() => HashCode.Combine(Name, Date, Circulation);

        public static bool operator ==(Edition left, Edition right) => Equals(left, right);

        public static bool operator !=(Edition left, Edition right) => !Equals(left, right);

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Edition otherEdition = obj as Edition;
            if (otherEdition != null)
            {
                return String.Compare(Name, otherEdition.Name, StringComparison.Ordinal);
            }

            throw new ArgumentException("Object is not a Edition");
        }

        public int Compare(Edition x, Edition y) => x.Date.CompareTo(y.Date) != 0 ? x.Date.CompareTo(y.Date) : 0;
    }
}
