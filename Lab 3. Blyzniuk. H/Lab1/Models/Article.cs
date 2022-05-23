using System;
using System.Collections.Generic;

namespace Lab1
{
    class Article : IRateAndCopy
    {
        public Person author;
        public string name;
        public double rating;

        public Article()
        {
            this.name = "article";
            this.rating = 78.5;
            this.author = new Person();
        }

        public Article(Person personInformation, string articleName, double articleRage)
        {
            author = personInformation;
            name = articleName;
            rating = articleRage;
        }

        public override string ToString() =>
            $"PersonInformation: \n {author},\n  ArticleName: {name},\n  ArticleRating: {rating}";

        //--------------------------------------------------------------------------------------
        //lab 2
        public override int GetHashCode() => HashCode.Combine(author, name, rating);

        public override bool Equals(object obj)
        {
            var article = obj as Article;
            return article != null &&
                   EqualityComparer<Person>.Default.Equals(author, article.author) &&
                   name == article.name &&
                   rating == article.rating;
        }
 
        public static bool operator ==(Article left, Article right) => Equals(left, right);

        public static bool operator !=(Article left, Article right) => !Equals(left, right);

        public double Raiting { 
            get => rating; 
        }

        public double Rating => rating;

        public virtual object DeepCopy() => MemberwiseClone();
    }
}
