using System;

namespace _02.Articles
{

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(Console.ReadLine());
            Article article = new Article(input[0], input[1], input[2]);

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(": ");
                string command = cmdArgs[0];
                string argument = cmdArgs[1];

                switch (command)
                {
                    case "Edit":
                        article.Edit(argument);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(argument);
                        break;
                    case "Rename":
                        article.Rename(argument);
                        break;
                }
            }

            Console.WriteLine(article);

        }


    }
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public void Edit(string content)
        {
            Content = content;
        }

        public void ChangeAuthor(string author)
        {
            Author = author;
        }

        public void Rename(string title)
        {
            Title = title;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
