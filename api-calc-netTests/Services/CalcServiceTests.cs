using api_calc_net.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace api_calc_net.Services.Tests
{
    [TestClass()]
    public class CalcServiceTests
    {
        [TestMethod]
        public void Calculate_ReturnsCorrectResult()
        {
            // Arrange
            var calculator = new CalcService();
            var input = new CalcInput { X = 10, Y = 5, Operation = "+" };
            var input1 = new CalcInput { X = 10, Y = 5, Operation = "-" };
            var input2 = new CalcInput { X = 10, Y = 5, Operation = "/" };
            var input3 = new CalcInput { X = 10, Y = 5, Operation = "*" };
            // Act
            var result = calculator.Calculate(input);
            var result1 = calculator.Calculate(input1);
            var result2 = calculator.Calculate(input2);
            var result3 = calculator.Calculate(input3);
            // Assert
            Assert.AreEqual(result, 15);
            Assert.AreEqual(result1, 5);
            Assert.AreEqual(result2, 2);
            Assert.AreEqual(result3, 50);
        }

        [TestMethod]
        public void Calculate_DivisionByZero_ThrowsException()
        {
            // Arrange
            var calculator = new CalcService();
            var input = new CalcInput { X = 10, Y = 0, Operation = "/" };
            // Act & Assert
            Assert.ThrowsException<BadHttpRequestException>(() => calculator.Calculate(input));
        }

        [TestMethod]
        public void CheckDivisionByZero_ShouldThrowException_WhenInputContainsDivisionByZero()
        {
            // Arrange
            var calculator = new CalcService();
            string input = "10/0";

            // Act & Assert
            Assert.ThrowsException<BadHttpRequestException>(() => calculator.CheckDivisionByZero(input));
        }

        [TestMethod]
        public void CheckDivisionByZero_ShouldNotThrowException_WhenInputDoesNotContainDivisionByZero()
        {
            // Arrange
            var calculator = new CalcService();
            string input = "10/5";

            // Act & Assert
            calculator.CheckDivisionByZero(input);
        }

        [TestMethod]
        public void CalculateFromString_ValidInput_ReturnsCorrectResult()
        {
            // Arrange
            var calculatorService = new CalcService();
            var input = new List<string>() { "2+2", "3*4", "1-6", "5/5" };
            var expectedOutput = new List<decimal>() { 4, 12, -5, 1 };

            // Act
            var result = calculatorService.CalculateFromString(input);

            // Assert
            CollectionAssert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void ValidateStringList_ValidInput_DoesNotThrowException()
        {
            // Arrange
            var calculator = new CalcService();

            // Act & Assert
            try
            {
                calculator.ValidateStringList(new List<string> { "1+2", "3/4" });
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected no exception, but got {ex.GetType().Name}: {ex.Message}");
            }
        }

        [TestMethod]
        public void ValidateStringList_DivisionByZero_ThrowsException()
        {
            // Arrange
            var calculator = new CalcService();

            // Act & Assert
            Assert.ThrowsException<BadHttpRequestException>(() => calculator.ValidateStringList(new List<string> { "1/0" }));
        }

        [TestMethod]
        public void ValidateStringList_InvalidInputFormat_ThrowsException()
        {
            // Arrange
            var calculator = new CalcService();

            // Act & Assert
            Assert.ThrowsException<BadHttpRequestException>(() => calculator.ValidateStringList(new List<string> { "1&2", "3/4/5" }));
        }

        [TestMethod]
        public void GetMinMaxIntList_ReturnsExpectedResult()
        {
            // Arrange
            var service = new CalcService();
            var input = new List<List<int>>
        {
            new List<int> { 1, 2, 3 },
            new List<int> { -10, 5, 100, 2 },
            new List<int> { 0 },
            new List<int> { 7, 7, 7, 7, 7 }
        };
            var expectedOutput = new List<MinMaxInt>
        {
            new MinMaxInt(Biggest: 3, Smallest: 1),
            new MinMaxInt(Biggest: 100, Smallest: -10),
            new MinMaxInt(Biggest: 0, Smallest: 0),
            new MinMaxInt(Biggest: 7, Smallest: 7)
        };
            // Act
            var actualOutput = service.GetMinMaxIntList(input);
            // Assert
            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void ValidateList_ArrayTooLong_ThrowsBadHttpRequestException()
        {
            // Arrange
            var calculator = new CalcService();
            var input = new List<int> { 1, 2, 3, 4, 5, 6 };

            // Act & Assert
            Assert.ThrowsException<BadHttpRequestException>(() => calculator.ValidateList(input));
        }
    }
}