using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class Magazine
    {
        private string magazineName;

        private Frequency frequency;

        private DateTime releaseDate;

        private int edition;

        private Article[] articleList;

        public double Rate { get; }

        public Magazine(
            string name,
            Frequency frequency,
            DateTime date,
            int edition
            )
        {
            this.magazineName = name;
            this.frequency = frequency;
            this.releaseDate = date;
            this.edition = edition;
        }

        public Magazine()
        {
            magazineName = string.Empty;
            frequency = Frequency.Monthly;
            releaseDate = DateTime.Now;
            edition = 0;
            articleList = null;
        }

        public string MagazineName {
            get => magazineName;
            set => magazineName = value;
        }

        public Frequency Frequency
        {
            get => frequency;
            set => frequency = value;
        }

        public bool this [Frequency value]
        {
            get => frequency == value
                ? true
                : false;
        }

        public DateTime ReleaseDate
        {
            get => releaseDate;
            set => releaseDate = value;
        }

        public Article[] ArticleList
        {
            get => articleList;
            set => articleList = value;
        }

        public void AddArticles(params Article[] articles)
        {
            if (articleList == null)
            {
                articleList = articles;
            }
            else
            {
                List<Article> articles1 = new List<Article>(articleList);
                articles1.AddRange(articles);
                articleList = articles1.ToArray();
            }
        }

        public override string ToString()
        {
            string result = string.Empty;
            result += "Name: " + magazineName;
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

            result += ' ' + releaseDate.ToString();
            result += ' ' + edition.ToString();
            result += ' ' + "Article list: \n";
            for (int  i = 0; i < articleList.Length; i++)
            {
                result += articleList[i].ToString();
                result += '\n';
            }
            return result;
        }

        public string ToShortString()
        {
            string result = string.Empty;
            result += "Article list: \n";
            for (int i = 0; i < articleList.Length; i++)
            {
                result += articleList[i].ToString();
                result += '\n';
            }
            return result;
        }
    }
}
