using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    public class MoodAnalyzerMain
    {
        public string message;
        public MoodAnalyzerMain()
        {

        }
        public MoodAnalyzerMain(string message)
        {
            this.message = message;
        }
        public string analyzeMood()
        {
            message = message.ToLower();
            if (message.Contains("happy"))
                return "Happy";
            else
                return "Sad";
        }
        
    }
}
