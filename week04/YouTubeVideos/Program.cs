using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# Programming Tutorial", "CodeMaster", 600);
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful for beginners."));
        video1.AddComment(new Comment("Charlie", "Can you make a part 2?"));

        Video video2 = new Video("OOP Principles Explained", "DevGuru", 720);
        video2.AddComment(new Comment("Diana", "Clear explanation of abstraction!"));
        video2.AddComment(new Comment("Ethan", "Helped me understand encapsulation."));
        video2.AddComment(new Comment("Fiona", "What about polymorphism?"));
        video2.AddComment(new Comment("George", "Perfect for my exam preparation."));

        Video video3 = new Video("Advanced C# Features", "ProCoder", 900);
        video3.AddComment(new Comment("Henry", "Lambdas are confusing."));
        video3.AddComment(new Comment("Ivy", "Great examples!"));
        video3.AddComment(new Comment("Jack", "Need more LINQ examples."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display video information and comments
        foreach (Video video in videos)
        {
            Console.WriteLine("=================================");
            Console.WriteLine(video.GetVideoInfo());
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetCommenterName()}: {comment.GetText()}");
            }
            Console.WriteLine();
        }
    }
}