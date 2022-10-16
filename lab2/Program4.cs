using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace OM
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string img { get; set; }
        

        public User(int id, string name, string img)
        {
            this.id = id;
            this.name = name;
            this.img = img;
        }

        public User()
        {

        }

        public override string ToString()
        {
            return $"{id} {name} {img}";
        }
    }

    public class UserFile
    {
        public List<User> users = new List<User>();

        public UserFile()
        {

        }

        public void Add(int id, string name, string img)
        {
            users.Add(new User(id, name, img));
        }

        public void CreatePOJsonU(string filename)
        {
            string json = JsonSerializer.Serialize(users);

            File.WriteAllText(filename, json);
        }
        public void CreatePOXmlU(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(OnlineMeeting));
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            using (fs)
            {
                serializer.Serialize(fs, this);
            }
        }




    }

    public class OnlineMeeting
    {
        public string date { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string nameOfUsersFile { get; set; }





        public OnlineMeeting(string date, string description, string url, string nameOfUsersFile)
        {
            this.date = date;
            this.description = description;
            this.url = url;
            this.nameOfUsersFile = nameOfUsersFile;
        }

        public OnlineMeeting()
        {

        }

        public override string ToString()
        {
            return $"{date}{description}{url}{nameOfUsersFile}";
        }
    }



    public class OnlineMeetingFile
    {
        public List<OnlineMeeting> onlinemeeting = new List<OnlineMeeting>();

        public OnlineMeetingFile()
        {

        }

        public void Add(string date, string description, string url , string nameOfUsersFile)
        {
            onlinemeeting.Add(new OnlineMeeting(date, description, url, nameOfUsersFile));
        }

        public void CreatePOJsonOM(string filename)
        {
            string json = JsonSerializer.Serialize(onlinemeeting);

            File.WriteAllText(filename, json);
        }
        public void CreatePOXmlOM(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(OnlineMeeting));
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            using (fs)
            {
                serializer.Serialize(fs, this);
            }
        }




    }


    internal class Program
    {
        static void Main(string[] args)
        {

            
           

            UserFile userFile=new UserFile();
            userFile.Add(1, "Nika", "https://kartinkin.net/uploads/posts/2022-03/1647908437_1-kartinkin-net-p-klassnie-kartinki-dlya-devochek-1.jpg");
            userFile.Add(2, "Vika", "https://abrakadabra.fun/uploads/posts/2021-11/1636651859_2-abrakadabra-fun-p-krasivie-avatarki-iz-pinteresta-2.jpg");



           

            
            


          
           


            Console.WriteLine("1 - Json File");
            Console.WriteLine("2 - Xml File");
            var typeOfFile=int.Parse(Console.ReadLine());
            if (typeOfFile == 1)
            {
                OnlineMeetingFile onlinemeetings = new OnlineMeetingFile();
                onlinemeetings.Add("09.06.2021", "meeting about weather forecast", "ggi-yu-lkk", "C:\\Users\\NIKA\\source\\repos\\ConsoleApp6\\ConsoleApp6\\jsconfig1.json");
                onlinemeetings.Add("12.07.2019", "meeting about famine", "nii-ooo-lkk", "C:\\Users\\NIKA\\source\\repos\\ConsoleApp6\\ConsoleApp6\\jsconfig1.json");
                string fileNameJsonOM = @"C:\Users\NIKA\source\repos\ConsoleApp6\ConsoleApp6\jsconfig3.json";
                string fileNameJsonU = @"C:\Users\NIKA\source\repos\ConsoleApp6\ConsoleApp6\jsconfig1.json";
                userFile.CreatePOJsonU(fileNameJsonU);
                onlinemeetings.CreatePOJsonOM(fileNameJsonOM);
            }
            if(typeOfFile == 2)
            {
                OnlineMeetingFile onlinemeetings = new OnlineMeetingFile();
                onlinemeetings.Add("09.06.2021", "meeting about weather forecast", "ggi-yu-lkk", "C:\\Users\\NIKA\\source\\repos\\ConsoleApp6\\ConsoleApp6\\XMLFile1.xml");
                onlinemeetings.Add("12.07.2019", "meeting about famine", "nii-ooo-lkk", "C:\\Users\\NIKA\\source\\repos\\ConsoleApp6\\ConsoleApp6\\XMLFile1.xml");
                string fileNameXmlOM = @"C:\Users\NIKA\source\repos\ConsoleApp6\ConsoleApp6\XMLFile3.xml";
                string fileNameXmlU = @"C:\Users\NIKA\source\repos\ConsoleApp6\ConsoleApp6\XMLFile1.xml";
                userFile.CreatePOJsonU(fileNameXmlU);
                onlinemeetings.CreatePOJsonOM(fileNameXmlOM);
            }


        }
    }
}