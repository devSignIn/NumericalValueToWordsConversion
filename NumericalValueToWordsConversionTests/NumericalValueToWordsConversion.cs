using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumericalValueToWords.Extensions;

namespace NumericalValueToWordsConversionTests
{
    [TestClass]
    public class NumericalValueToWordsConversion
    {
        [TestMethod]
        public void TestNumericalValueToWordsConversion()
        {
            string wordsConversionFromHundred = NumericalValueToWordsExtension.NumberToWords(255);
            Assert.AreEqual("two hundred fifty-five", wordsConversionFromHundred);

            string wordsConversionFromQuintillion = NumericalValueToWordsExtension.NumberToWords(12345678912345678912);
            Assert.AreEqual("twelve quintillion three hundred forty-five quadrillion six hundred seventy-eight trillion nine hundred twelve billion three hundred forty-five million six " +
                            "hundred seventy-eight thousand nine hundred twelve", wordsConversionFromQuintillion);
        }
    }
}
