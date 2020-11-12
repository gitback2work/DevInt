using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DevInt.Core.Calculators
{
    public class StringCalculatorTests
    {
        string emptyString = "";
        string oneNumber = "7";
        string twoNumbers = "11,54";
        string multiple = "9,5,34,7,89,3,6,54";
        string validNewLines = "1\n2,3";
        string validNewLines2 = "9,5,34,7\n89,3\n6,54"; 
        string invalidNewLines = "1,\n";        
        string customDelimited = "//;\n1;2";
        string negativeNumbers = "1,1,2,3,5,8,-8,13,21,-26,9001,34";
        string numbersOver1000 = "2,1001,13";
        string multipleDelimiters = "//*%\n1*2%3";

        [Fact]
        public void C1CanHandleEmptyString()
        {
            //Arrange
            var calculator = new StringCalculator();

            //Act
            var result = calculator.C1Add(emptyString);

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void C1CanHandleOneNumber()
        {
            //Arrange
            var calculator = new StringCalculator();

            //Act
            var result = calculator.C1Add(oneNumber);

            //Assert
            Assert.Equal(7, result);
        }

        [Fact]
        public void C1CanHandleTwoNumbers()
        {
            //Arrange
            var calculator = new StringCalculator();

            //Act
            var result = calculator.C1Add(twoNumbers);

            //Assert
            Assert.Equal(65, result);
        }

        [Fact]
        public void C2CanHandleMultipleNumbers()
        {
            //Arrange
            var calculator = new StringCalculator();

            //Act
            var resultEmpty = calculator.C2Add(emptyString);
            var resultOne = calculator.C2Add(oneNumber);
            var resultMultiple = calculator.C2Add(multiple);

            //Assert
            Assert.Equal(0, resultEmpty);
            Assert.Equal(7, resultOne);
            Assert.Equal(207, resultMultiple);
        }

        [Fact]
        public void C3CanHandleNewLineCharacters()
        {
            //Arrange
            var calculator = new StringCalculator();

            //Act          
            var resultEmpty = calculator.C3Add(emptyString);
            var resultOne = calculator.C3Add(oneNumber);
            var resultMultiple = calculator.C3Add(multiple);
            var resultValidNewLines = calculator.C3Add(validNewLines);
            var resultValidNewLine2 = calculator.C3Add(validNewLines2);
            
            //Assert
            Assert.Equal(0, resultEmpty);
            Assert.Equal(7, resultOne);
            Assert.Equal(207, resultMultiple);
            Assert.Equal(6, resultValidNewLines);
            Assert.Equal(207, resultValidNewLine2);
            Assert.Throws<ArgumentException>(() => calculator.C3Add(invalidNewLines));
            
        }

        [Fact]
        public void C4CanSupportDifferentDelimiters()
        {
            //Arrange
            var calculator = new StringCalculator();

            //Act
            var resultEmpty = calculator.C4Add(emptyString);
            var resultOne = calculator.C4Add(oneNumber);
            var resultMultiple = calculator.C4Add(multiple);
            var resultValidNewLines = calculator.C4Add(validNewLines);
            var resultValidNewLine2 = calculator.C4Add(validNewLines2);
            var resultCustomDelimited = calculator.C4Add(customDelimited);
            
            //Assert
            Assert.Equal(0, resultEmpty);
            Assert.Equal(7, resultOne);
            Assert.Equal(207, resultMultiple);
            Assert.Equal(6, resultValidNewLines);
            Assert.Equal(207, resultValidNewLine2);
            //Asserting that an exception is thrown if input is incorrect, though
            //more details on the exception are not instrumented for this particular assertion
            Assert.Throws<ArgumentException>(() => calculator.C4Add(invalidNewLines));
            Assert.Equal(3, resultCustomDelimited);
            
        }

        [Fact]
        public void C5CanHandleNegativeValues()
        {
            //Arrange
            var calculator = new StringCalculator();

            //Act
            var resultEmpty = calculator.C5Add(emptyString);
            var resultOne = calculator.C5Add(oneNumber);
            var resultMultiple = calculator.C5Add(multiple);
            var resultValidNewLines = calculator.C5Add(validNewLines);
            var resultValidNewLine2 = calculator.C5Add(validNewLines2);
            var resultCustomDelimited = calculator.C5Add(customDelimited);
            

            //Assert
            Assert.Equal(0, resultEmpty);
            Assert.Equal(7, resultOne);
            Assert.Equal(207, resultMultiple);
            Assert.Equal(6, resultValidNewLines);
            Assert.Equal(207, resultValidNewLine2);
            //Asserting that an exception is thrown if input is incorrect, though
            //more details on the exception are not instrumented for this particular assertion
            Assert.Throws<ArgumentException>(() => calculator.C5Add(invalidNewLines));
            Assert.Equal(3, resultCustomDelimited);
            
            //Could use a standard ArgumentException here but we try to be more specific
            //and indicate range is the issue here for negative input
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => calculator.C5Add(negativeNumbers));
            Assert.Equal("source", exception.ParamName);
            Assert.StartsWith("Negatives not allowed", exception.Message);
            //As per comments in StringCalculator, we test here to make sure we are sending back
            //a valid list of negative numbers in the Data dictionary
            var lstNegatives = (List<int>)exception.Data["negatives"];
            Assert.Equal(2, lstNegatives.Count); //do we have 2 negative numbers?
            Assert.Equal(-26, lstNegatives[1]); //are they the ones in the test string?

        }

        [Fact]
        public void C6CanHandleNumbersOver1000()
        {
            //Arrange
            var calculator = new StringCalculator();

            //Act
            var resultEmpty = calculator.C6Add(emptyString);
            var resultOne = calculator.C6Add(oneNumber);
            var resultMultiple = calculator.C6Add(multiple);
            var resultValidNewLines = calculator.C6Add(validNewLines);
            var resultValidNewLine2 = calculator.C6Add(validNewLines2);
            var resultCustomDelimited = calculator.C6Add(customDelimited);
            var resultNumbersOver1000 = calculator.C6Add(numbersOver1000);


            //Assert
            Assert.Equal(0, resultEmpty);
            Assert.Equal(7, resultOne);
            Assert.Equal(207, resultMultiple);
            Assert.Equal(6, resultValidNewLines);
            Assert.Equal(207, resultValidNewLine2);
            //Asserting that an exception is thrown if input is incorrect, though
            //more details on the exception are not instrumented for this particular assertion
            Assert.Throws<ArgumentException>(() => calculator.C6Add(invalidNewLines));
            Assert.Equal(3, resultCustomDelimited);

            //Could use a standard ArgumentException here but we try to be more specific
            //and indicate range is the issue here for negative input
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => calculator.C6Add(negativeNumbers));
            Assert.Equal("source", exception.ParamName);
            Assert.StartsWith("Negatives not allowed", exception.Message);
            //As per comments in StringCalculator, we test here to make sure we are sending back
            //a valid list of negative numbers in the Data dictionary
            var lstNegatives = (List<int>)exception.Data["negatives"];
            Assert.Equal(2, lstNegatives.Count); //do we have 2 negative numbers?
            Assert.Equal(-26, lstNegatives[1]); //are they the ones in the test string?

            Assert.Equal(15, resultNumbersOver1000);
        }

        [Fact]
        public void C7CanHandleMultipleDelimiters()
        {
            //Arrange
            var calculator = new StringCalculator();

            //Act
            var resultEmpty = calculator.C7Add(emptyString);
            var resultOne = calculator.C7Add(oneNumber);
            var resultMultiple = calculator.C7Add(multiple);
            var resultValidNewLines = calculator.C7Add(validNewLines);
            var resultValidNewLine2 = calculator.C7Add(validNewLines2);
            var resultCustomDelimited = calculator.C7Add(customDelimited);
            var resultNumbersOver1000 = calculator.C7Add(numbersOver1000);
            var resultmultipleDelimiters = calculator.C7Add(multipleDelimiters);

            

            //Assert
            Assert.Equal(0, resultEmpty);
            Assert.Equal(7, resultOne);
            Assert.Equal(207, resultMultiple);
            Assert.Equal(6, resultValidNewLines);
            Assert.Equal(207, resultValidNewLine2);
            //Asserting that an exception is thrown if input is incorrect, though
            //more details on the exception are not instrumented for this particular assertion
            Assert.Throws<ArgumentException>(() => calculator.C7Add(invalidNewLines));
            Assert.Equal(3, resultCustomDelimited);

            //Could use a standard ArgumentException here but we try to be more specific
            //and indicate range is the issue here for negative input
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => calculator.C7Add(negativeNumbers));
            Assert.Equal("source", exception.ParamName);
            Assert.StartsWith("Negatives not allowed", exception.Message);
            //As per comments in StringCalculator, we test here to make sure we are sending back
            //a valid list of negative numbers in the Data dictionary
            var lstNegatives = (List<int>)exception.Data["negatives"];
            Assert.Equal(2, lstNegatives.Count); //do we have 2 negative numbers?
            Assert.Equal(-26, lstNegatives[1]); //are they the ones in the test string?

            Assert.Equal(15, resultNumbersOver1000);
            Assert.Equal(6, resultmultipleDelimiters);

        }

    }
}
