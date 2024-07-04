using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xunit;
using BidCalculator.IntegrationTest.TestData;
using BidCalculator.IntegrationTest.Utilities;
using BidCalculatorApi.Model;

namespace BidCalculator.IntegrationTest
{
    public class FeeCalculatorControllerTests
    {
        private readonly HttpClient _client;

        public FeeCalculatorControllerTests()
        {
            _client = WebApplicationFactorySetup.CreateClient();
        }
        [Theory]
        [MemberData(nameof(FeeCalculatorTestData.ValidFeeCalculationTestData), MemberType = typeof(FeeCalculatorTestData))]
        public async Task CalculateTotalCost_ShouldReturnExpectedResult(Vehicle request, FeeCalculationResult expected)
        {
            var payload = new
            {
                BasePrice = request.BasePrice,
                Type = (int)request.Type  
            };

            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/FeeCalculator/CalculateTotalCost", content);

            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Assert.True(false, $"Request failed with status code {response.StatusCode} and content: {responseContent}");
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<FeeCalculationResult>(responseString);

            Assert.Equal(expected.BasePrice, result.BasePrice);
            Assert.Equal(expected.BasicFee, result.BasicFee);
            Assert.Equal(expected.SpecialFee, result.SpecialFee);
            Assert.Equal(expected.AssociationFee, result.AssociationFee);
            Assert.Equal(expected.StorageFee, result.StorageFee);
            Assert.Equal(expected.TotalCost, result.TotalCost);
        }

        [Theory]
        [MemberData(nameof(FeeCalculatorTestData.InvalidFeeCalculationTestData), MemberType = typeof(FeeCalculatorTestData))]
        public async Task CalculateTotalCost_InvalidInputs_ShouldReturnBadRequest(decimal basePrice, string type)
        {
            var payload = new
            {
                BasePrice = basePrice,
                Type = type
            };

            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/FeeCalculator/CalculateTotalCost", content);

            var responseContent = await response.Content.ReadAsStringAsync();

            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Contains("error", responseContent, StringComparison.OrdinalIgnoreCase);
        }
    }
}
