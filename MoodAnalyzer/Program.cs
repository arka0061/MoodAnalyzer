using System;

namespace MoodAnalyzer
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Mood Analyzer!");
            MoodAnalyzerMain mood = new MoodAnalyzerMain(null);           
            string message = mood.AnalyzeMood();        
            Console.WriteLine(message);
        }
    }
}

