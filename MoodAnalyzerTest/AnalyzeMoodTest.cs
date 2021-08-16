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
    }
}