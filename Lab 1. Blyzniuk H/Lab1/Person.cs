using System;

namespace Lab1
{
    public class Person
    {

        private string name;
        private string surname;
        private DateTime birthday;

        public Person(string name, string surname, DateTime birthday) =>
            (this.name, this.surname, this.birthday) = (name, surname, birthday);

        public Person() : this(string.Empty, string.Empty, DateTime.Now) { }

        public string Name
        {
            get => this.name;

            set
            {
                if (!string.IsNullOrEmpty(value))
                    this.name = value;
            }
        }

        public string Surname
        {
            get => this.surname;

            set
            {
                if (!string.IsNullOrEmpty(value))
                    this.surname = value;
            }
        }

        public DateTime DateTime
        {
            get => this.birthday;
            set => this.birthday = value;
        }

        public int BirthdayYear
        {
            get => this.birthday.Year;
            set
            {
                if (value >= 0)
                    this.birthday = new DateTime(
                        value, this.birthday.Month, this.birthday.Day);
            }
        }

        public override string ToString() =>
            string.Format("{0}, {1}",
                ToShortString(), this.birthday.ToString("dd MMMM yyyy"));

        public virtual string ToShortString() =>
            string.Format("{0} {1}",
                this.name, this.surname);
    }
}
