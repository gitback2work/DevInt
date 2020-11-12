using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace DevInt.Core.Calculators
{
    // Assume all numbers in input string are integers as there is no instruction
    //on how to convert to int32 resultCom[leted exercise
    public class StringCalculator
    {
        public StringCalculator()
        {
        }

        public int C1Add(string source)
        {
            var calcValue = 0;
            if (string.IsNullOrEmpty(source)) return calcValue;

            var lstNumbers = source.Split(",");

            if(lstNumbers.Length == 1)
            {
                Int32.TryParse(lstNumbers[0], out calcValue);
            }
            else
            {
                Int32.TryParse(lstNumbers[0], out int first);
                Int32.TryParse(lstNumbers[1], out int second);
                calcValue = first + second;
            }

            return calcValue;

        }

        public int C2Add(string source)
        {
            var calcValue = 0;
            if (string.IsNullOrEmpty(source)) return calcValue;

            var lstNumbers = source.Split(",");

            foreach(var item in lstNumbers)
            {
                Int32.TryParse(item, out int number);
                calcValue += number;
            }

            return calcValue;

        }

        public int C3Add(string source)
        {
            var calcValue = 0;
            if (string.IsNullOrEmpty(source)) return calcValue;

            //First clean up input string
            source = source.Replace("\n", ",");

            //and get the list if numbers
            var lstNumbers = source.Split(",");

            //For invalid new line character, according to example,
            //we will end up with number items which are empty strings
            //so check for empty string but only if more than 1 number
            var emptyExists = (lstNumbers.Count() > 1) && lstNumbers.Contains("");
            if(emptyExists)
            {
                throw new ArgumentException("Invalid input string", "source");
            }

            foreach (var item in lstNumbers)
            {
                Int32.TryParse(item, out int number);
                calcValue += number;
            }

            return calcValue;

        }

        public int C4Add(string source)
        {
            var calcValue = 0;
            if (string.IsNullOrEmpty(source)) return calcValue;

            var delimiter = ",";

            //First see if there is a custom delimiter in a header record
            if (source.Length > 5)
            {
                if ((source.Substring(0, 2) == "//") && (source.Substring(3, 1) == "\n"))
                {
                    delimiter = source.Substring(2, 1);
                    source = source.Substring(4); //remove the header with the delimiter
                }
            }

            //Next clean up input string
            source = source.Replace("\n", delimiter);

            //and get the list of numbers
            var lstNumbers = source.Split(delimiter);

            //For invalid new line character, according to example,
            //we will end up with number items which are empty strings
            //so check for empty string but only if more than 1 number
            var emptyExists = (lstNumbers.Count() > 1) && lstNumbers.Contains("");
            if (emptyExists)
            {
                throw new ArgumentException("Invalid input string", "source");
            }

            foreach (var item in lstNumbers)
            {
                Int32.TryParse(item, out int number);
                calcValue += number;
            }

            return calcValue;

        }
            
        public int C5Add(string source)
        {
            var calcValue = 0;
            if (string.IsNullOrEmpty(source)) return calcValue;

            var delimiter = ",";

            //First see if there is a custom delimiter in a header record
            if (source.Length > 5)
            {
                if ((source.Substring(0, 2) == "//") && (source.Substring(3, 1) == "\n"))
                {
                    delimiter = source.Substring(2, 1);
                    source = source.Substring(4); //remove the header with the delimiter
                }
            }

            //Next clean up input string
            source = source.Replace("\n", delimiter);

            //and get the list if numbers
            var lstNumbers = source.Split(delimiter);

            //For invalid new line character, according to example,
            //we will end up with number items which are empty strings
            //so check for empty string but only if more than 1 number
            var emptyExists = (lstNumbers.Count() > 1) && lstNumbers.Contains("");
            if (emptyExists)
            {
                throw new ArgumentException("Invalid input string", "source");
            }

            // To deal with multiple possible negative values, and report them, it will
            // be easier to transpose the list to one of integers and operate on that instead
            var lstIntegers = new List<Int32>();
            foreach (var item in lstNumbers)
            {
                Int32.TryParse(item, out int number);
                lstIntegers.Add(number);
            }

            //Get list of negative integers, if any
            var lstNegativeIntegers = (from ent in lstIntegers
                                       where (ent < 0)
                                       select ent).ToList();

            if (lstNegativeIntegers.Count > 0)
            {
                var concatNegatives = string.Join(",", lstNegativeIntegers);
                var message = $"Negatives not allowed. Found:{concatNegatives}";
                
                var exception = new ArgumentOutOfRangeException("source", message);

                //That exception message works as requested but could be more helpful if we provided
                //the list of negative numbers in a more useable format. It could be further processed 
                //or analysed by Serilog for example
                exception.Data["negatives"] = lstNegativeIntegers;
                throw exception;
            }

            calcValue = lstIntegers.Sum();

            return calcValue;

        }

        public int C6Add(string source)
        {
            var calcValue = 0;
            if (string.IsNullOrEmpty(source)) return calcValue;

            var delimiter = ",";

            //First see if there is a custom delimiter in a header record
            if (source.Length > 5)
            {
                if ((source.Substring(0, 2) == "//") && (source.Substring(3, 1) == "\n"))
                {
                    delimiter = source.Substring(2, 1);
                    source = source.Substring(4); //remove the header with the delimiter
                }
            }

            //Next clean up input string
            source = source.Replace("\n", delimiter);

            //and get the list if numbers
            var lstNumbers = source.Split(delimiter);

            //For invalid new line character, according to example,
            //we will end up with number items which are empty strings
            //so check for empty string but only if more than 1 number
            var emptyExists = (lstNumbers.Count() > 1) && lstNumbers.Contains("");
            if (emptyExists)
            {
                throw new ArgumentException("Invalid input string", "source");
            }

            // To deal with multiple possible negative values, and report them, it will
            // be easier to transpose the list to one of integers and operate on that instead
            var lstIntegers = new List<Int32>();
            foreach (var item in lstNumbers)
            {
                Int32.TryParse(item, out int number);
                lstIntegers.Add(number);
            }

            //Get list of negative integers, if any
            var lstNegativeIntegers = (from ent in lstIntegers
                                       where (ent < 0)
                                       select ent).ToList();

            if (lstNegativeIntegers.Count > 0)
            {
                var concatNegatives = string.Join(",", lstNegativeIntegers);
                var message = $"Negatives not allowed. Found:{concatNegatives}";

                var exception = new ArgumentOutOfRangeException("source", message);

                //That exception message works as requested but could be more helpful if we provided
                //the list of negative numbers in a more useable format. It could be further processed 
                //or analysed by Serilog for example
                exception.Data["negatives"] = lstNegativeIntegers;
                throw exception;
            }

            //Simply remove of elements greater than 1000
            lstIntegers = (from ent in lstIntegers
                           where (ent <= 1000)
                           select ent).ToList();

            calcValue = lstIntegers.Sum();

            return calcValue;

        }

        public int C7Add(string source)
        {
            var calcValue = 0;
            if (string.IsNullOrEmpty(source)) return calcValue;

            var delimiter = ","; //set the default delimiter

            //we will process a string called payload. For now, set this to source as default
            var payload = source;


            //First see if there is a custom delimiter(s) in a header record
            if ((source.Length >= 4) && (source.StartsWith("//"))) //Make sure the length is long enough to have a header record
                                                                   //and we can do the following string manipulations
            {
                //If the source string begins with "//" and there is a line break, then consider
                //these characters represent the delimiter record header and the characters in between
                //are the delimiter characters
                var startIndex = source.IndexOf("//"); //always == 0. Just added for clarity
                var endIndex = source.IndexOf("\n");

                var allDelimiters = source.Substring(2, (endIndex - 2));
                //payload then is the source trng with the delimiter record header removed
                payload = source.Substring(endIndex + 1);

                //By definition, delimiter characters only represent delimiting positions (and not input numbers)
                //so we can choose the first one as the new default and replace all the others with it
                //First get the array of characters
                var arrDelimiters = allDelimiters.ToCharArray();
                delimiter = arrDelimiters[0].ToString();

                for (int i = 1; i < arrDelimiters.Length; i++)
                {
                    //convert each char to a string
                    var delim = arrDelimiters[i].ToString();
                    payload = payload.Replace(delim, delimiter);
                }

            }

            //Next clean up input string to remove any new line characters
            payload = payload.Replace("\n", delimiter);

            //and get the list if numbers
            var lstNumbers = payload.Split(delimiter);

            //For invalid new line character, according to example,
            //we will end up with number items which are empty strings
            //so check for empty string but only if more than 1 number
            var emptyExists = (lstNumbers.Count() > 1) && lstNumbers.Contains("");
            if (emptyExists)
            {
                throw new ArgumentException("Invalid input string", "source");
            }

            // To deal with multiple possible negative values, and report them, it will
            // be easier to transpose the list to one of integers and operate on that instead
            var lstIntegers = new List<Int32>();
            foreach (var item in lstNumbers)
            {
                Int32.TryParse(item, out int number);
                lstIntegers.Add(number);
            }

            //Get list of negative integers, if any
            var lstNegativeIntegers = (from ent in lstIntegers
                                       where (ent < 0)
                                       select ent).ToList();

            if (lstNegativeIntegers.Count > 0)
            {
                var concatNegatives = string.Join(",", lstNegativeIntegers);
                var message = $"Negatives not allowed. Found:{concatNegatives}";

                var exception = new ArgumentOutOfRangeException("source", message);

                //That exception message works as requested but could be more helpful if we provided
                //the list of negative numbers in a more useable format. It could be further processed 
                //or analysed by Serilog for example
                exception.Data["negatives"] = lstNegativeIntegers;
                throw exception;
            }

            //Simply remove of elements greater than 1000
            lstIntegers = (from ent in lstIntegers
                           where (ent <= 1000)
                           select ent).ToList();

            calcValue = lstIntegers.Sum();

            return calcValue;

        }

    }
}