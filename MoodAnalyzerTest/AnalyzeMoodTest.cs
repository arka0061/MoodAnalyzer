using MoodAnalyzer;
using NUnit.Framework;

namespace MoodAnalyzerTest
{
    public class AnalyzeMoodTest
    {
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// TC 1.1
        /// </summary>
        [Test]
        public void GivenSadMessage_WhenAnalyze_ShouldReturnSad()
        {
            MoodAnalyzerMain mood = new MoodAnalyzerMain("I am in Sad Mood");
            string actual = mood.AnalyzeMood(); 
            Assert.AreEqual(actual,"Sad");
        }
        /// <summary>
        /// TC 1.2
        /// </summary>
        [Test]
        public void GivenHappyMessage_WhenAnalyze_ShouldReturnHappy()
        {
            MoodAnalyzerMain mood = new MoodAnalyzerMain("I am in Happy Mood");
            string actual = mood.AnalyzeMood();
            Assert.AreEqual(actual, "Happy");
        }
        /// <summary>
        /// TC 2.1
        /// </summary>
        [Test]
        public void GivenNullMessage_WhenAnalyze_ShouldReturnException()
        {
            MoodAnalyzerMain mood = new MoodAnalyzerMain(null);
            string actual = mood.AnalyzeMood();
            Assert.AreEqual(actual, "Happy");
        }
        /// <summary>
        /// TC-3.1
        /// </summary>
        [Test]
        public void GivenNullMood_WhenAnalyze_ShouldReturnException()
        {
            string expected = "Mood should not be null";
            try
            {
                MoodAnalyzerMain mood = new MoodAnalyzerMain(null);
                string actual = mood.AnalyzeMood();
            }
            catch (MoodAnalyzerException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        /// <summary>
        /// TC-3.2
        /// </summary>
        [Test]
        public void GivenEmptyMood_WhenAnalyze_ShouldReturnException()
        {
            string expected = "Mood should not be empty";
            try
            {
                MoodAnalyzerMain moodAnalyser = new MoodAnalyzerMain("");
                string actual = moodAnalyser.AnalyzeMood();
            }
            catch (MoodAnalyzerException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        /// <summary>
        /// TC 4.1
        /// </summary>
        [Test]
        public void GivenMoodAnalyzerReflection_WhenAnalyze_ShouldReturnObject()
        {
            object expected = new MoodAnalyzerMain();
            object actual = MoodAnalyzerReflector.CreateMoodAnalyzerObject("MoodAnalyzer.MoodAnalyzerMain", "MoodAnalyzerMain");
            expected.Equals(actual);
        }
       /// <summary>
       /// TC 4.2
       /// </summary>
        [Test]
        public void GivenImproperClassName_WhenAnalyze_ShouldReturnMoodAnalyzerException()
        {
            string expected = "Class not found";
            try
            {
                object actual = MoodAnalyzerReflector.CreateMoodAnalyzerObject("MoodAnalyzer.MoodAnalyzerMain", "MoodAnalyzerMain");
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        /// TC-4.3 
        /// </summary>
        [Test]
        public void GivenImproperConstructorName_WhenAnalyze_ShouldReturnMoodAnalyzerException()
        {
            string expected = "Constructor not found";
            try
            {
                object actual = MoodAnalyzerReflector.CreateMoodAnalyzerObject("MoodAnalyzer.MoodAnalyzerMain", "MoodAnalyzerMain");
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        /// TC 5.1
        /// </summary>
        [Test]
        public void GivenMoodAnalyserParameterizedConstructor_ShouldReturnObject()
        {
            object expected = new MoodAnalyzerMain("Parameterized Constructor");
            object actual = MoodAnalyzerReflector.CreateMoodAnalyserParameterizedConstructor("MoodAnalyzer.MoodAnalyzerMain", "MoodAnalyser", "Parameterized Constructor");
            expected.Equals(actual);
        }
        /// <summary>
        /// TC 5.2 
        /// </summary>
        [Test]
        public void GivenClassNameImproperParameterizedConstructor_WhenAnalyze_ShouldReturnMoodAnalyzerException()
        {
            string expected = "Class not found";
            try
            {
                object actual = MoodAnalyzerReflector.CreateMoodAnalyserParameterizedConstructor("MoodAnalyzer.MoodAnalyzerMain", "MoodAnalyzer", "Parameterized Constructor");
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        /// TC 5.3 
        /// </summary>
        [Test]
        public void GivenImproperParameterizedConstructorName_WhenAnalyze_ShouldReturnMoodAnalyzerException()
        {
            string expected = "Constructor not found";
            try
            {
                object actual = MoodAnalyzerReflector.CreateMoodAnalyserParameterizedConstructor("MoodAnalyzer.MoodAnalyzerMain", "MoodAnalyzer", "Parameterized Constructor");
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        /// TC 6.1
        /// </summary>
        [Test]
        public void InvokeMethodReflection_ShouldRetunHappy()
        {
            string expected = "happy";
            string actual = MoodAnalyzerReflector.InvokeAnalyseMood("happy", "AnalyzeMood");
            expected.Equals(actual);
        }
        /// <summary>
        /// TC 6.2 
        /// </summary>
        [Test]
        public void GivenImproperMethodName_WhenAnalyze_ShouldReturnMoodAnalyzerException()
        {
            string expected = "No method found";
            try
            {
                string actual = MoodAnalyzerReflector.InvokeAnalyseMood("I am happy", "Mood");
                expected.Equals(actual);
            }
            catch (MoodAnalyzerException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        /// <summary>
        /// TC 7.1
        /// </summary>
        [Test]
        public void GivenDynamicMood_WhenAnalyze_ShouldReturnHappy()
        {
            string expected = "Happy";
            string actual = MoodAnalyzerReflector.SetFieldDynamic("Happy", "message");
            expected.Equals(actual);
        }
        /// <summary>
        /// TC 7.2
        /// </summary>
        public void GivenImproperFiledName_WhenAnalyze_ShouldThrowMoodAnalyzerException()
        {
            string expected = "Field not found";
            try
            {
                string actual = MoodAnalyzerReflector.SetFieldDynamic("Happy", "message");
                expected.Equals(actual);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        /// TC 7.3
        /// </summary>
        [Test]
        public void GivenNullMessage_WhenAnalyze_ShouldReturnMoodAnalyzerException()
        {
            string expected = "Message should not be null";
            try
            {
                string actual = MoodAnalyzerReflector.SetFieldDynamic(null, "message");
                expected.Equals(actual);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
    }
}