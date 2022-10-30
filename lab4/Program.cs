using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    class Program
    {
        public interface IObserver
        {
            // get updates from publisher
            void Update(ISubject subject);
        }
        public interface ISubject
        {
            // attaches users to news
            void Attach(IObserver observer, string type);

            // detaches users from news
            void Detach(IObserver observer, string type);

            // notifies user when news is added
            void Notify(string type);
        }

        public class TextNews
        {
            public string title;
            public List<string> topic;
            public string text;
            public TextNews(string title, List<string> topic, string text)
            {
                this.title = title;
                this.topic = topic;
                this.text = text;
            }
            public override string ToString()
            {
                return $"{this.title}";
            }
        }

        public class VideoNews
        {
            public string title;
            public List<string> topic;
            public string url;
            public VideoNews(string title, List<string> topic, string url)
            {
                this.title = title;
                this.topic = topic;
                this.url = url;
            }
            public override string ToString()
            {
                return $"{this.title}";
            }
        }

        public class NewsFeed : ISubject
        {
            public List<TextNews> text_news = new List<TextNews> { };
            public List<VideoNews> video_news = new List<VideoNews> { };

            public List<IObserver> text_observers = new List<IObserver>(); // users subscribed to text news
            public List<IObserver> video_observers = new List<IObserver>(); // users subscribed to video news

            public void Attach(IObserver observer, string type)
            {
                if (type == "t")
                {
                    Console.WriteLine($"NewsFeed: New user subscribed to text news.");
                    this.text_observers.Add(observer);
                }
                if (type == "v")
                {
                    Console.WriteLine("NewsFeed: New user subscribed to video news.");
                    this.video_observers.Add(observer);
                }
                if (type == "tv")
                {
                    Console.WriteLine("NewsFeed: New user subscribed to text & video news.");
                    this.text_observers.Add(observer);
                    this.video_observers.Add(observer);
                }
            }

            public void Detach(IObserver observer, string type)
            {
                if (type == "t")
                {
                    Console.WriteLine("NewsFeed: User unsubscribed from text news.");
                    this.text_observers.Remove(observer);
                }
                if (type == "v")
                {
                    Console.WriteLine("NewsFeed: User unsubscribed from video news.");
                    this.video_observers.Remove(observer);
                }
                if (type == "tv")
                {
                    Console.WriteLine("NewsFeed: User unsubscribed from text & video news.");
                    this.text_observers.Remove(observer);
                    this.video_observers.Remove(observer);
                }
            }

            public void Notify(string type)
            {
                if (type == "t")
                {
                    Console.WriteLine("NewsFeed: Notifying text subscribers...");

                    foreach (var observer in text_observers)
                    {
                        observer.Update(this);
                    }
                }
                if (type == "v")
                {
                    Console.WriteLine("NewsFeed: Notifying video subscribers...");

                    foreach (var observer in video_observers)
                    {
                        observer.Update(this);
                    }
                }
                if (type == "tv")
                {
                    Console.WriteLine("NewsFeed: Notifying all subscribers...");

                    foreach (var observer in text_observers.Concat(video_observers))
                    {
                        observer.Update(this);
                    }
                }
            }

            public void AddedTextNews(TextNews news)
            {
                this.text_news.Add(news);
                Console.WriteLine(text_news.Last());
                this.Notify("t");

            }
            public void AddedVideoNews(VideoNews news)
            {
                this.video_news.Add(news);
                Console.WriteLine(video_news.Last());
                this.Notify("v");
            }
        }


        class Subscriber : IObserver
        {
            public string name;
            public Subscriber(string name)
            {
                this.name = name;
            }
            public void Update(ISubject subject)
            {
                if ((subject as NewsFeed).text_news.Count != 0 || (subject as NewsFeed).text_news.Count != 0)
                {
                    Console.WriteLine($"{name}: Reacted to the news.");
                }
            }
        }

        static void Main(string[] args)
        {
            var news = new NewsFeed();
            var s1 = new Subscriber("Nika");
            var s2 = new Subscriber("Mary");
            var s3 = new Subscriber("Lisa");


            var t1 = new TextNews("Smiling sunshine: NASA captures shots of coronal holes causing happy face on the sun",
                new List<string> { "NASA", "sun" },
                "NASA has shared an image of the sun \"smiling\", after one of their satellites " +
                "captured patterns on its surface appearing to show a happy face....");


            var t2 = new TextNews("Doctor removes 23 contact lenses from eye of patient who 'forgot to take them out for almost a month'",
                new List<string> { "contact lenses", "Doctor" },
                "A doctor has shared a bizarre video of her removing 23 contact lenses from a patient's eye. " +
                "Dr Katerina Kurteeva posted the clip on Instagram of her teasing the lenses ....");

            var v1 = new VideoNews("Man wakes to find his property covered in tumbleweed",
                new List<string> { "tumbleweed", "property" },
                "https://news.sky.com/video/man-wakes-to-find-his-property-covered-in-tumbleweed-12728902");

            var v2 = new VideoNews("Swiss firm claims longest passenger train record with 1.2-mile-long locomotive",
                new List<string> { "locomotive", "record" },
                "https://news.sky.com/video/swiss-firm-claims-longest-passenger-train-record-with-1-2-mile-long-locomotive-12733467");

            news.Attach(s1, "t"); // Nika subscribed to text news
            news.Attach(s2, "t"); // Mary subscribed to text news
            news.AddedTextNews(t1);  // added 1st text news

            Console.WriteLine("\n * * * * *\n ");

            news.Detach(s2, "t"); // Mary unsubscirber from text news
            news.AddedTextNews(t2);

            Console.WriteLine("\n * * * * *\n ");

            news.Attach(s1, "v"); // Nika subscribed to video news
            news.Attach(s3, "v"); // Lisa subscribed to video news
            news.Attach(s2, "tv"); // Mary subscribed to text & video news
            news.AddedVideoNews(v1);

            Console.WriteLine("\n * * * * *\n ");

            news.Detach(s1, "v"); // Nika unsubscirber from video news
            news.AddedVideoNews(v2);
        }
    }
}