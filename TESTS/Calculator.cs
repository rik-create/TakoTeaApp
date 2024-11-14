using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TakoTea.TESTS
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

public class CalculatorTests
    {
        [Fact]
        public void Add_ReturnsCorrectSum_WhenGivenTwoIntegers()
        {
            // Arrange
            var calculator = new Calculator();
            int a = 3;
            int b = 5;

            // Act
            int result = calculator.Add(a, b);

            // Assert
            Assert.Equal(8, result); // Assert that the result is 8
        }
    }




}
