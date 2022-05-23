using System;

namespace Lab1
{
    class Person
    {
        private string _firstName;
        private string _lastName;
        private System.DateTime _birthday;

        public Person()
        {
            _firstName = "A";
            _lastName = "B";
            _birthday = DateTime.UtcNow;
        }

        public Person(string firstName, string lastName, System.DateTime birthday)
        {
            _firstName = firstName;
            _lastName = lastName;
            _birthday = birthday;
        }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }
        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public DateTime Birthday
        {
            get => _birthday;
            set => _birthday = value;
        }

        public int BirtdayYear
        {
            get => _birthday.Year;
            set => _birthday = new DateTime(value, _birthday.Month, _birthday.Day);
        }

        public override string ToString() => 
            $"First Name: {_firstName}, Last Name: {_lastName},  Birthday: {_birthday}";

        public virtual string ToShortString() => $"{_firstName} {_lastName}";


        //-------------------------------------------------------------------------------------
        // lab 2

        public override bool Equals(object obj)
        {
            var person = obj as Person;
            return person != null &&
                   _firstName == person._firstName &&
                   _lastName == person._lastName &&
                   _birthday == person._birthday;
        }

        public static bool operator ==(Person left, Person right) => Equals(left, right);

        public static bool operator !=(Person left, Person right) => !Equals(left, right);

        public virtual object DeepCopy() => MemberwiseClone();

        public override int GetHashCode() => HashCode.Combine(_firstName, _lastName, _birthday);

    }
}
