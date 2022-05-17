using System;
using System.Collections.Generic;

namespace Lab2
{
    public class Magazine: Edition, IRateAndCopy
    {
        private Frequency frequency;

        private Person[] editors;

        private Article[] articles;

        public double Rate { get; }

        public Magazine(
            string name,
            Frequency frequency,
            DateTime date,
            int edition
            ) : base(name, date, edition)
        {
            this.frequency = frequency;
        }

        public Magazine() : this(string.Empty, Frequency.Monthly, DateTime.Today, 0) { }


        public string MagazineName
        {
            get => Name;
            set => Name = value;
        }

        public Frequency Frequency
        {
            get => frequency;
            set => frequency = value;
        }

        public bool this[Frequency value]
        {
            get => frequency == value;
        }

        public bool this[double value]
        {
            get => Rating > value;
        }

        public DateTime ReleaseDate
        {
            get => Date;
            set => Date = value;
        }


        // lab 2
        public Article[] Articles
        {
            get => articles;
            set => articles = value;
        }

        public Person[] Editors
        {
            get => editors;
            set => editors = value;
        }

        public Edition Edition
        {
            get => new Edition(Name, Date, Circulation);
            set
            {
                Name = value.Name;
                Date = value.Date;
                Circulation = value.Circulation;
            }
        }

        public double Rating => AverageRate;

        public bool this[string value]
        {
            get => Name.Contains(value);
        }

        public double AverageRate
        {
            get
            {
                double allRate = 0.0f;
                foreach (Article article in articles)
                {
                    allRate += article.Rating;
                }
                return allRate / articles.Length;
            }
        }

        public void AddArticles(params Article[] articleArray)
        {
            if (articles == null)
            {
                articles = articleArray;
            }
            else
            {
                List<Article> articles1 = new List<Article>(articles);
                articles1.AddRange(articleArray);
                articles = articles1.ToArray();
            }
        }

        public override string ToString()
        {
            string result = string.Empty;
            result += "Name: " + Name;
            if (frequency == Frequency.Weekly)
            {
                result += ", " + "Frequency: weekly";
            }
            else if (frequency == Frequency.Monthly)
            {
                result += ", " + "Frequency: monthly";
            }
            else
            {
                result += ", " + "Frequency: yearly";
            }

            result += ", Date: " + Date.ToString("dd MMMM yyyy");
            result += ", Circulation: " + Circulation.ToString();
            result += ' ' + "Article list: \n";

            foreach (var article in articles)
            {
                result += article.ToString();
                result += '\n';
            }

            foreach (var editor in editors)
            {
                result += editor.ToString();
                result += '\n';
            }

            result += ", Average rate: " + AverageRate.ToString();
            return result;
        }

        public string ToShortString()
        {
            string result = string.Empty;
            if (frequency == Frequency.Weekly)
            {
                result += ", " + "Frequency: weekly";
            }
            else if (frequency == Frequency.Monthly)
            {
                result += ", " + "Frequency: monthly";
            }
            else
            {
                result += ", " + "Frequency: yearly";
            }

            result += ", Date: " + Date.ToString("dd MMMM yyyy");
            result += ", Circulation: " + Circulation.ToString();
            result += ", Average rate: " + AverageRate.ToString();
            return result;
        }


        // lab2

        public void AddEditors(params Person[] persons)
        {
            if (editors == null)
            {
                editors = persons;
            }
            else
            {
                List<Person> editors1 = new List<Person>(editors);
                editors1.AddRange(persons);
                editors = editors1.ToArray();
            }
        }

        public override object DeepCopy()
        {
            Magazine magazine = (Magazine)MemberwiseClone();
            magazine.Editors = new Person[0];
            magazine.Articles = new Article[0];

            foreach (Person person in Editors)
            {
                magazine.AddEditors(person.DeepCopy() as Person);
            }

            foreach (Article article in Articles)
            {
                magazine.AddArticles(article.DeepCopy() as Article);
            }

            return magazine;
        }

    }
}
