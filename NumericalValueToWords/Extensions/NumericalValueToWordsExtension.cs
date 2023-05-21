using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumericalValueToWords.Extensions
{
    /// <summary>
    /// Extension menthod for numerical to words conversion.
    /// </summary>
    public static class NumericalValueToWordsExtension
    {
        private static readonly Dictionary<ulong, string> _numberToWordsMap = new Dictionary<ulong, string>
        {
            [1_000_000_000_000_000_000] = "quintillion",
            [1_000_000_000_000_000] = "quadrillion",
            [1_000_000_000_000] = "trillion",
            [1_000_000_000] = "billion",
            [1_000_000] = "million",
            [1_000] = "thousand",
            [100] = "hundred",
            [90] = "ninety",
            [80] = "eighty",
            [70] = "seventy",
            [60] = "sixty",
            [50] = "fifty",
            [40] = "forty",
            [30] = "thirty",
            [20] = "twenty",
            [19] = "nineteen",
            [18] = "eighteen",
            [17] = "seventeen",
            [16] = "sixteen",
            [15] = "fifteen",
            [14] = "fourteen",
            [13] = "thirteen",
            [12] = "twelve",
            [11] = "eleven",
            [10] = "ten",
            [9] = "nine",
            [8] = "eight",
            [7] = "seven",
            [6] = "six",
            [5] = "five",
            [4] = "four",
            [3] = "three",
            [2] = "two",
            [1] = "one",
            [0] = "zero"
        };

        /// <summary>
        /// Convert numerical value to words.
        /// </summary>
        /// <param name="num">Unsigned Integer</param>
        /// <returns>String</returns>
        public static string NumberToWords(ulong number)
        {
            var sb = new StringBuilder();
            var delimiter = String.Empty;
            
            AppendNumbersToWords(number);

            // Append numbers based on the _numberToWords map.
            void AppendNumbersToWords(ulong dividend)
            {
                // If number exits in the _numberToWords map directly
                // append to words. Otherwise, break the number in quotient
                // and remainder based on the entry lower than the number
                // in _numberToWords map and then append to words.
                if (_numberToWordsMap.ContainsKey(dividend))
                {
                    AppendDelimitedWord(dividend);
                }
                else
                {
                    var divisor = _numberToWordsMap.Where(x => x.Key <= dividend).Select(x => x.Key).First();
                    var quotient = dividend / divisor;
                    var remainder = dividend % divisor;

                    if (quotient > 0 && divisor >= 100)
                    {
                        AppendNumbersToWords(quotient);
                    }

                    AppendDelimitedWord(divisor);

                    if (remainder > 0)
                    {
                        AppendNumbersToWords(remainder);
                    }
                }
            }

            void AppendDelimitedWord(ulong number)
            {
                sb.Append(delimiter);
                sb.Append(_numberToWordsMap[number]);
                delimiter = 20 <= number && number < 100 ? "-" : " ";
            }

            return sb.ToString();
        }

    }
}
