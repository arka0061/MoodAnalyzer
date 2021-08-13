using System;

namespace MoodAnalyzer
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Mood Analyzer!");
            MoodAnalyzerMain mood = new MoodAnalyzerMain("I am in a Happy Mood");           
            string message = mood.analyzeMood();        
            Console.WriteLine("Mood is " + message);
        }
    }
}

