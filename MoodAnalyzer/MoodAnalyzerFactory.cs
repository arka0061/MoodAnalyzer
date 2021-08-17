using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzer
{
    public class MoodAnalyzerFactory
    {
        public static object CreateMoodAnalyzerObject(string className, string constructor)
        {
            string p = @"." + constructor + "$";
            Match result = Regex.Match(className, p);
            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = assembly.GetType(className);
                    var res = Activator.CreateInstance(moodAnalyserType);
                    return res;
                }
                catch (Exception ex)
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND, "Class not found");
                }
            }
            else
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor not found");
            }
        }
    }
}
