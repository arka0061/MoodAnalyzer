using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzer
{
    public class MoodAnalyzerReflector
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
        public static object CreateMoodAnalyserParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = Type.GetType(className);
            try
            {
                if (type.FullName.Equals(className) || type.Name.Equals(className))
                {
                    if (type.Name.Equals(constructorName))
                    {
                        ConstructorInfo info = type.GetConstructor(new[] { typeof(string) });
                        object instance = info.Invoke(new object[] { message });
                        return instance;
                    }
                    else
                    {
                        throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor not found");
                    }
                }
                else
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND, "Class not found");
                }
            }
            catch (Exception e)
            {
                return e;
            }
        }
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = typeof(MoodAnalyzerMain);
                MethodInfo methodInfo = type.GetMethod(methodName);             
                object moodAnalyserObject = MoodAnalyzerReflector.CreateMoodAnalyserParameterizedConstructor("MoodAnalyzer.MoodAnalyzerMain", "MoodAnalyzerMain", message);
                object info = methodInfo.Invoke(moodAnalyserObject, null);
                return info.ToString();
            }
            catch (NullReferenceException e)
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND, "No method found");
            }

        }
        public static string SetFieldDynamic(string message, string fieldName)
        {
            try
            {
                MoodAnalyzerMain moodAnalyze = new MoodAnalyzerMain();
                Type type = typeof(MoodAnalyzerMain);
                FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NULL_MOOD, "Message should not be null");
                }
                fieldInfo.SetValue(moodAnalyze, message);
                return moodAnalyze.message;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_FIELD, "Field not found");
            }
        }
    }
}

