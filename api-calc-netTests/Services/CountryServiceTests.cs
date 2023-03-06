using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace api_calc_net.Services.Tests
{
    [TestClass()]
    public class CountryServiceTests
    {

        [TestMethod]
        public void CreateCountryList_ShouldReturnSortedCountryNames()
        {
            // Arrange
            var countryService = new CountryService();
            string responseJson = @"[
        {""name"":{""common"":""United States"",""official"":""United States of America"",""nativeName"":{""eng"":{""official"":""United States of America"",""common"":""United States""}}}},
        {""name"":{""common"":""India"",""official"":""Republic of India"",""nativeName"":{""eng"":{""official"":""Republic of India"",""common"":""India""}}}},
        {""name"":{""common"":""China"",""official"":""People's Republic of China"",""nativeName"":{""zho"":{""official"":""中华人民共和国"",""common"":""中国""}}}}
         ]";
            var expectedCountryNames = new List<string> { "China", "India", "United States" };

            // Act
            var actualCountryNames = countryService.CreateCountryList(responseJson);

            // Assert
            CollectionAssert.AreEqual(expectedCountryNames, actualCountryNames);
        }

        [TestMethod]
        public void CreateCountryList_ReturnsCorrectList()
        {

            // Arrange
            var countryService = new CountryService();
            string response = "[{\"name\": {\"common\": \"Afghanistan\"}}, {\"name\": {\"common\": \"Albania\"}}]";

            // Act
            List<string> result = countryService.CreateCountryList(response);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Afghanistan", result[0]);
            Assert.AreEqual("Albania", result[1]);
        }

        [TestMethod]
        public async Task GetContriesAsync_ReturnsCountriesList()
        {
            // Arrange
            var countryService = new CountryService();

            // Act
            var result = await countryService.GetContriesAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.countries);
            Assert.IsTrue(result.countries.Count > 0);
        }
    }
}