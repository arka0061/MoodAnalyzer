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
            MoodAnalyzerMain mood = new MoodAnalyzerMain();
            string actual = mood.analyzeMood("I am in Sad Mood");
            Assert.AreEqual(actual,"Sad");
        }
        /// <summary>
        /// TC 1.2
        /// </summary>
        [Test]
        public void GivenHappyMessage_WhenAnalyze_ShouldReturnHappy()
        {
            MoodAnalyzerMain mood = new MoodAnalyzerMain();
            string actual = mood.analyzeMood("I am in Happy Mood");
            Assert.AreEqual(actual, "Happy");
        }
    }
}