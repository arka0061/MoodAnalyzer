using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    public class MoodAnalyzerMain
    {
        public MoodAnalyzerMain()
        {

        }
        public string analyzeMood(string message)
        {
            message = message.ToLower();
            if (message.Contains("happy"))
                return "Happy";
            else
                return "Sad";
        }
        
    }
}
