namespace TestingReverseTexr
{
    using NUnit.Framework;
    using TMPTASKWEB.Function;

    [TestFixture]
    public class StringManipulationTests
    {
        [Test]
        public void TestIsEvenString()
        {

            string evenText = "ab";
            string even2Text = "a";


            bool isEven1 = ReverseString.IsEvenString(evenText);
            bool isEven2 = ReverseString.IsEvenString(even2Text);


            Assert.IsTrue(isEven1);
            Assert.IsFalse(isEven2);
        }
        [Test]
        public void TestReverseString()
        {
            string text = "hello";
            string ReversedText = "olleh";

            string reversedText = ReverseString.Reverse(text);

            Assert.AreEqual(ReversedText, reversedText);
        }
        [Test]
        public void TestReverseandEvenString()
        {
            string text = "hello";
            string ReversedText = "ollehhello";

            string reversedText = ReverseString.Get(text);

            Assert.AreEqual(ReversedText, reversedText);
        }
        [Test]
        public void TestTreeSort()
        {
            string text = "abdbabba";
            char[] array = text.ToCharArray();

            string Sortedstring = "aaabbbbd";

            string sortedstring = new string(TreeSort.Sort(array));

            Assert.AreEqual(Sortedstring, sortedstring);
        }
        [Test]
        public void TestQuickSort()
        {
            string text = "abdbabba";
            char[] array = text.ToCharArray();

            string Sortedstring = "aaabbbbd";

            string sortedstring = new string(QuickSort.Sort(array, 0, array.Length - 1));

            Assert.AreEqual(Sortedstring, sortedstring);
        }
        [Test]
        public void TestQuickSortSwap()
        {
            string text = "ab";
            char[] array = text.ToCharArray();

            string Swapstring = "ba";

            QuickSort.Swap(ref array[0], ref array[1]);
            string swapstring = new string(array);

            Assert.AreEqual(Swapstring, swapstring);
        }
        [Test]
        public void TestIsValidString()
        {

            string validText = "ddsdafdfda";
            string validText2 = "DASDAweqqwe";
            string validText3 = "meme";
            string[] backlist = { "meme" };

            bool isValid1 = StringManager.IsValid(validText, backlist);
            bool isValid2 = StringManager.IsValid(validText2, backlist);
            bool isValid3 = StringManager.IsValid(validText3, backlist);

            Assert.IsTrue(isValid1 && StringManager.isblackword);
            Assert.IsFalse(isValid2 && StringManager.isblackword);
            Assert.IsFalse(isValid3 && !StringManager.isblackword);
        }
        [Test]
        public void TestRepetitionSymbol()
        {

            string repitiontext = "dadadadadada";

            string[] RepetitionSymbol = { "d - 6", "a - 6" };
            string[] repetitionSymbol = RepetitionString.OutputSymbol(repitiontext);

            Assert.AreEqual(RepetitionSymbol, repetitionSymbol);
        }
        [Test]
        public void TestVowelSubstring()
        {
            string repitiontext = "dadadadadada";

            string VowelSubstring = "adadadadada";
            string vowelSubstring = RepetitionString.OutputVowelSubstring(repitiontext);

            Assert.AreEqual(VowelSubstring, vowelSubstring);
        }
    }
}
