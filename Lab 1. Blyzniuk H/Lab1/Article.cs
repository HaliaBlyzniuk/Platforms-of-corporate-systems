using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class Article
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
            string.Format("Autor: {0}, Article name: {1}, rate: {2}",
                Person.ToString(), ArticleName, Rate);

    }
}
