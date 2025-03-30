using System;
using System.Collections.Generic;

// Comment class to track commenter's name and text
class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

// Video class to track title, author, length, and comments
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Length in seconds
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        // Creating a list of videos
        List<Video> videos = new List<Video>();

        // Creating videos
        Video video1 = new Video("Introduction to C#", "John Doe", 600);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Looking forward to more.") );

        Video video2 = new Video("Advanced OOP in C#", "Jane Smith", 1200);
        video2.AddComment(new Comment("Dave", "Really insightful."));
        video2.AddComment(new Comment("Eve", "The examples were great!"));
        video2.AddComment(new Comment("Frank", "I learned a lot."));

        Video video3 = new Video("C# Design Patterns", "Mark Lee", 900);
        video3.AddComment(new Comment("Grace", "Perfect for my project!"));
        video3.AddComment(new Comment("Henry", "Could you do more on Singleton?"));
        video3.AddComment(new Comment("Ivy", "Loved the explanations!"));

        // Adding videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Displaying video information
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
