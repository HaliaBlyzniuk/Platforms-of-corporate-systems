using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
 
    class Magazine : Edition, IRateAndCopy
    {
        public List<Person> Editors { get; set; }
        public List<Article> Articles { get; set; }

        private Frequency _periodicity;

        public Magazine() : this("default Magazine",
            Frequency.Weekly,
            new DateTime(),
            0,
            new List<Person> { new Person() },
            new List<Article> { new Article()
            })
        { }

        public Magazine(string magazineName, 
            Frequency periodicity, 
            DateTime magazineDate, 
            int magazineCirculation, 
            List<Person> personsList, 
            List<Article> articleList): base(magazineName, magazineDate, magazineCirculation)
        {
            _periodicity = periodicity;
            Editors = personsList;
            Articles = articleList;
        }

        public Frequency Periodicity
        {
            get => _periodicity;
            set => _periodicity = value;
        }
        
        public bool this[Frequency index]
        {
            get => _periodicity == index;
        }

        public double MiddleRate
        {
            get
            {
                double allRanges = 0;
                foreach (Article article in Articles)
                {
                    allRanges += article.rating;
                }
                return allRanges / Articles.Count;
            }
        }

        public void AddArticles(params Article[] article)
        {
            if (article != null)
            {
                Articles.AddRange(article);
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var article in Articles)
            {
                stringBuilder.AppendLine(article.ToString());
            }
           
            stringBuilder.AppendLine("Persons:");
            foreach (var person in Editors)
            {
                stringBuilder.AppendLine(person.ToString());
            }
           
            return $" MagazineName: {Name},\n Periodicity: {Periodicity},\n MagazineDate: {Date}," +
                $"\n Article: {stringBuilder},\n MiddleRate: {MiddleRate}\n";
        }

        public virtual string ToShortString() =>
            $" MagazineName: {Name},\n Periodicity: {Periodicity},\n MagazineDate: {Date},\n MiddleRate: {MiddleRate}\n";

        public void AddEditors(params Person[] person)
        {
            if (person != null)
            {
                Editors.AddRange(person);
            }
        }

        

        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Editors, Articles, Periodicity, MiddleRate);

        public static bool operator ==(Magazine left, Magazine right) => Equals(left, right);

        public static bool operator !=(Magazine left, Magazine right) => !Equals(left, right);

        public override object DeepCopy()
        {
            Magazine other = (Magazine)MemberwiseClone();
            other.Editors = new List<Person>();
            other.Articles = new List<Article>();

            foreach (Person person in Editors)
            {
                other.Editors.Add((Person)person.DeepCopy());
            }
            foreach (Article article in Articles)
            {
                other.Articles.Add((Article)article.DeepCopy());
            }

            return other;
        }

        public Edition EditionBase
        {
            get => new Edition(Name, Date, Circulation);
            set
            {
                Name = value.Name;
                Date = value.Date;
                Circulation = value.Circulation;
            }
        }

        public double Rating => MiddleRate;

        public IEnumerable GetArticlesMoreThan(double lowValue)
        {
            foreach (Article article in Articles)
            {
                if (article.rating > lowValue)
                {
                    yield return article;
                }
            }
        }

        public IEnumerable GetArticlesWithText(string text)
        {
            foreach (Article article in Articles)
            {
                if (article.name.Contains(text))
                {
                    yield return article;
                }
            }
        }

        public override bool Equals(object obj) =>
            obj is Magazine magazine && base.Equals(obj) &&
            EqualityComparer<List<Person>>.Default.Equals(Editors, magazine.Editors) &&
            EqualityComparer<List<Article>>.Default.Equals(Articles, magazine.Articles) &&
            Periodicity == magazine.Periodicity &&
            MiddleRate == magazine.MiddleRate &&
            EqualityComparer<Edition>.Default.Equals(EditionBase, magazine.EditionBase) &&
            Rating == magazine.Rating;
    }
}
