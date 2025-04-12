using System;
using System.Collections.Generic;

class Program
{
    // Comment class
    public class Comment
    {
        private string _name;
        private string _text;
        private DateTime _date;

        public Comment(string name, string text)
        {
            _name = name;
            _text = text;
            _date = DateTime.Now;
        }

        public string GetName() => _name;
        public string GetText() => _text;
        public string GetDate() => _date.ToShortDateString();
    }

    // Video class
    public class Video
    {
        private string _title;
        private string _author;
        private int _length;
        private List<Comment> _comments;
        private int _views;
        private int _likes;

        public Video(string title, string author, int length)
        {
            _title = title;
            _author = author;
            _length = length;
            _comments = new List<Comment>();
            _views = 0;
            _likes = 0;
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public int GetCommentsCount()
        {
            return _comments.Count;
        }

        public void DisplayComments()
        {
            foreach (var comment in _comments)
            {
                Console.WriteLine($"Comment by {comment.GetName()} on {comment.GetDate()}: {comment.GetText()}");
            }
        }

        public void View()
        {
            _views++;
            Console.WriteLine($"You are watching: {_title}");
        }

        public void Like()
        {
            _likes++;
            Console.WriteLine($"You liked: {_title}");
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Title: {_title}");
            Console.WriteLine($"Author: {_author}");
            Console.WriteLine($"Length: {_length} seconds");
            Console.WriteLine($"Views: {_views}");
            Console.WriteLine($"Likes: {_likes}");
            Console.WriteLine($"Comment Count: {GetCommentsCount()}");
            DisplayComments();
        }
    }

    // Main method
    static void Main(string[] args)
    {
        var video1 = new Video("Video 1", "Author 1", 300);
        video1.AddComment(new Comment("Muna Uche", "Great video!"));
        video1.AddComment(new Comment("Nmeso CHim", "I agree, very informative."));

        var video2 = new Video("Video 2", "Author 2", 240);
        video2.AddComment(new Comment("Praise Johnson", "Love the music!"));
        video2.AddComment(new Comment("Mike Davis", "Very engaging video."));

        var video3 = new Video("Video 3", "Author 3", 420);
        video3.AddComment(new Comment("David Lee", "Excellent content!"));
        video3.AddComment(new Comment("Sophia Patel", "Well done!"));

        var videos = new List<Video> { video1, video2, video3 };

        foreach (var video in videos)
        {
            video.DisplayDetails();
            video.View();
            video.Like();
            Console.WriteLine();
        }
    }
}