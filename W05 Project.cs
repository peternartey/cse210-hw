import time
import random
import sys

class Activity:
    def __init__(self, name, description):
        self.name = name
        self.description = description
    
    def start_activity(self, duration):
        print(f"Starting {self.name} Activity")
        print(self.description)
        print("Prepare to begin...")
        self.show_spinner(3)
        self.run_activity(duration)
        self.end_activity(duration)
    
    def run_activity(self, duration):
        pass  # To be implemented by subclasses
    
    def end_activity(self, duration):
        print("Well done!")
        print(f"You have completed the {self.name} activity for {duration} seconds.")
        self.show_spinner(3)
    
    def show_spinner(self, seconds):
        for _ in range(seconds):
            sys.stdout.write("\r|")
            time.sleep(0.5)
            sys.stdout.write("\r/")
            time.sleep(0.5)
            sys.stdout.write("\r-")
            time.sleep(0.5)
            sys.stdout.write("\r\\")
            time.sleep(0.5)
        sys.stdout.write("\r ")
        print("")

class BreathingActivity(Activity):
    def __init__(self):
        super().__init__("Breathing", "This activity will help you relax by guiding you through breathing exercises.")
    
    def run_activity(self, duration):
        elapsed = 0
        while elapsed < duration:
            print("Breathe in...")
            self.show_countdown(3)
            print("Breathe out...")
            self.show_countdown(3)
            elapsed += 6
    
    def show_countdown(self, seconds):
        for i in range(seconds, 0, -1):
            sys.stdout.write(f"\r{i}")
            time.sleep(1)
        sys.stdout.write("\r ")
        print("")

class ReflectionActivity(Activity):
    PROMPTS = [
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    ]
    QUESTIONS = [
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What did you learn from this experience?"
    ]
    
    def __init__(self):
        super().__init__("Reflection", "This activity will help you reflect on moments of strength and resilience.")
    
    def run_activity(self, duration):
        prompt = random.choice(self.PROMPTS)
        print(prompt)
        self.show_spinner(3)
        elapsed = 0
        while elapsed < duration:
            question = random.choice(self.QUESTIONS)
            print(question)
            self.show_spinner(3)
            elapsed += 5

class ListingActivity(Activity):
    PROMPTS = [
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?"
    ]
    
    def __init__(self):
        super().__init__("Listing", "This activity will help you reflect on positive aspects of your life by listing them.")
    
    def run_activity(self, duration):
        prompt = random.choice(self.PROMPTS)
        print(prompt)
        self.show_countdown(3)
        start_time = time.time()
        count = 0
        while (time.time() - start_time) < duration:
            input("Enter an item: ")
            count += 1
        print(f"You listed {count} items!")

class MindfulnessApp:
    def __init__(self):
        self.activities = {
            "1": BreathingActivity(),
            "2": ReflectionActivity(),
            "3": ListingActivity()
        }
    
    def run(self):
        while True:
            print("Choose an activity:")
            print("1. Breathing")
            print("2. Reflection")
            print("3. Listing")
            print("4. Exit")
            choice = input("Enter your choice: ")
            if choice == "4":
                break
            if choice in self.activities:
                duration = int(input("Enter duration in seconds: "))
                self.activities[choice].start_activity(duration)
            else:
                print("Invalid choice, try again.")

if __name__ == "__main__":
    app = MindfulnessApp()
    app.run()
