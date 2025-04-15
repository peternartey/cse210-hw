using System;

public class MindfulnessApp
{
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            if (choice == "4") break;

            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                _ => null
            };

            if (activity != null)
            {
                Console.Write("Enter duration in seconds: ");
                if (int.TryParse(Console.ReadLine(), out int duration))
                {
                    activity.StartActivity(duration);
                }
                else
                {
                    Console.WriteLine("Invalid duration.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

            Console.WriteLine();
        }
    }
}
