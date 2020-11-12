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
        string invalidNewLines = "1,\n";
        string validNewLines2 = "9,5,34,7\n89,3\n6,54";
        string customDelimited = "//;\n1;2";

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
        public void C3CanHandleNewLines()
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
        public void C4CanAdd()
        {
            //Arrange
            var calculator = new StringCalculator();

            //Act
            var resultEmpty = calculator.Add(emptyString);
            var resultOne = calculator.Add(oneNumber);
            var resultMultiple = calculator.Add(multiple);
            var resultValidNewLines = calculator.Add(validNewLines);
            var resultValidNewLine2 = calculator.Add(validNewLines2);
            var resultCustomDelimited = calculator.Add(customDelimited);

            //Assert
            Assert.Equal(0, resultEmpty);
            Assert.Equal(7, resultOne);
            Assert.Equal(207, resultMultiple);
            Assert.Equal(6, resultValidNewLines);
            Assert.Equal(207, resultValidNewLine2);
            Assert.Throws<ArgumentException>(() => calculator.Add(invalidNewLines));
            Assert.Equal(3, resultCustomDelimited);
        }

    }
}
