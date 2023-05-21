using NumericalValueToWords.Extensions;
using System;

namespace NumericalValueToWords
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Get user input for a number to words conversion.
            Console.WriteLine("Type any number:  ");

            ulong x;

            if (ulong.TryParse(Console.ReadLine(), out x))
            {
                // Ignore negative numbers and invalid inputs. Only, convert positive numbers to words.
                if(x < 0)
                {
                    Console.WriteLine("Please enter a positive number.");
                }
                else
                {
                    try
                    {
                        string wordsConversion = NumericalValueToWordsExtension.NumberToWords(x);
                        Console.WriteLine($"Words conversion of {x} numerical value is : {wordsConversion}");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Exception occured while conversion, please try again.");
                    }
                    
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a number.");
            }
        }
    }
}
