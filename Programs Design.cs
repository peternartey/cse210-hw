using System;
using System.Collections.Generic;

class Video
{
    public string Title { get; set; }
    public double Duration { get; set; }
    private int Likes { get; set; }
    private int Dislikes { get; set; }
    private int Views { get; set; }

    public Video(string title, double duration)
    {
        Title = title;
        Duration = duration;
        Likes = 0;
        Dislikes = 0;
        Views = 0;
    }

    public void Play()
    {
        Views++;
        Console.WriteLine($"Playing: {Title}");
    }

    public void Like() => Likes++;
    public void Dislike() => Dislikes++;
}

class User
{
    public string Username { get; set; }
    private List<Video> WatchHistory;

    public User(string username)
    {
        Username = username;
        WatchHistory = new List<Video>();
    }

    public void WatchVideo(Video video)
    {
        video.Play();
        WatchHistory.Add(video);
    }
}

class YouTubePlatform
{
    private List<Video> Videos = new List<Video>();
    private List<User> Users = new List<User>();

    public void AddVideo(Video video) => Videos.Add(video);
    public void RegisterUser(User user) => Users.Add(user);
    public Video GetVideoByTitle(string title) => Videos.Find(v => v.Title == title);
}

class Program
{
    static void Main()
    {
        YouTubePlatform platform = new YouTubePlatform();
        User user = new User("JohnDoe");
        Video video = new Video("C# Abstraction", 10.5);

        platform.RegisterUser(user);
        platform.AddVideo(video);

        user.WatchVideo(video);
    }
}
