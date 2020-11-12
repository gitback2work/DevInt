using System;
using System.Linq;

namespace DevInt.Core.Calculators
{
    // Assume all numbers in input string are integers as there is no instruction
    //on how to convert to int32 result
    public class StringCalculator
    {
        public StringCalculator()
        {
        }

        public int C1Add(string source)
        {
            var calcValue = 0;

            var lstNumbers = source.Split(",");

            switch(lstNumbers.Length)
            {
                case 0:
                    calcValue= 0;
                    break;

                case 1:
                    Int32.TryParse(lstNumbers[0], out calcValue);
                    break;

                case 2:
                    Int32.TryParse(lstNumbers[0], out int first);
                    Int32.TryParse(lstNumbers[1], out int second);
                    calcValue = first + second;
                    break;

                default:
                    break;
            }

            return calcValue;

        }

        public int C2Add(string source)
        {
            var calcValue = 0;

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

            //First clean up input string
            source = source.Replace("\n", ",");
            var lstNumbers = source.Split(",");

            //For invalid new line character, according to example,
            //we will end up with number items which are empty strings
            //so check for empty string but only if more than 1 number
            var emptyExists = (lstNumbers.Count() > 1) && lstNumbers.Contains("");
            if(emptyExists)
            {
                throw new ArgumentException("Invalid input string");
            }

            foreach (var item in lstNumbers)
            {
                Int32.TryParse(item, out int number);
                calcValue += number;
            }

            return calcValue;

        }

        public int Add(string source)
        {
            var calcValue = 0;
            var delimiter = ",";

            //First see if there is a custom delimiter
            if(source.Length > 5)
            {
                if((source.Substring(0,2) == "//") && (source.Substring(3,1) == "\n"))
                 {
                    delimiter = source.Substring(2, 1);
                    source = source.Substring(4); //remove the header
                }
            }

            //First clean up input string
            source = source.Replace("\n", delimiter);
            var lstNumbers = source.Split(delimiter);

            //For invalid new line character, according to example,
            //we will end up with number items which are empty strings
            //so check for empty string but only if more than 1 number
            var emptyExists = (lstNumbers.Count() > 1) && lstNumbers.Contains("");
            if (emptyExists)
            {
                throw new ArgumentException("Invalid input string");
            }

            foreach (var item in lstNumbers)
            {
                Int32.TryParse(item, out int number);
                calcValue += number;
            }

            return calcValue;

        }

    }
}