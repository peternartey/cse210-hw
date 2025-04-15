using System;

public class ReflectionActivity : Activity
{
    private static readonly string[] Prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions = {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What did you learn from this experience?"
    };

    public ReflectionActivity()
        : base("Reflection", "This activity will help you reflect on moments of strength and resilience.")
    {
    }

    protected override void RunActivity(int duration)
    {
        Random rand = new Random();
        Console.WriteLine(Prompts[rand.Next(Prompts.Length)]);
        ShowSpinner(3);

        int elapsed = 0;
        while (elapsed < duration)
        {
            Console.WriteLine(Questions[rand.Next(Questions.Length)]);
            ShowSpinner(3);
            elapsed += 5;
        }
    }
}
