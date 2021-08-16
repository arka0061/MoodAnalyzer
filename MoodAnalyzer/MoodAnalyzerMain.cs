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
        public string AnalyzeMood()
        {
            try
            {
                if (message == null)
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NULL_MOOD,"Mood should not be null");
                }
                if (message.Equals(string.Empty))
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.EMPTY_MOOD,"Mood should not be empty");
                }
                message.ToLower();
                if (message.Contains("happy"))
                    return "Happy";
                else
                    return "Sad";
            }
            catch (NullReferenceException)
            {
                return "Happy";
            }
        }
        
    }
}
