using System;

namespace MoodAnalyzer
{
    class Program
    {
        public static void Main(string[] args)
        {
            MoodAnalyzerMain mood = new MoodAnalyzerMain();
            Console.WriteLine("Welcome To Mood Analyzer!");          
            string message = mood.analyzeMood("I am in Happy Mood");
            Console.WriteLine("Mood is " + message);
        }
    }
}

