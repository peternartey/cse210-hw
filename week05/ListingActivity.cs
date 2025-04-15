using System;
using System.Diagnostics;

public class ListingActivity : Activity
{
    private static readonly string[] Prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?"
    };

    public ListingActivity()
        : base("Listing", "This activity will help you reflect on positive aspects of your life by listing them.")
    {
    }

    protected override void RunActivity(int duration)
    {
        Random rand = new Random();
        Console.WriteLine(Prompts[rand.Next(Prompts.Length)]);
        ShowCountdown(3);

        Stopwatch stopwatch = Stopwatch.StartNew();
        int count = 0;
        while (stopwatch.Elapsed.TotalSeconds < duration)
        {
            Console.Write("Enter an item: ");
            Console.ReadLine();
            count++;
        }
        Console.WriteLine($"You listed {count} items!");
    }
}
