using BidCalculatorApi.Model;
using BidCalculatorApi.Services.Implementations;
using Xunit;

namespace BidCalculator.UnitTest
{
    public class FeeCalculatorServiceTests
    {
        private readonly FeeCalculatorService _service;

        public FeeCalculatorServiceTests()
        {
            _service = new FeeCalculatorService();
        }

        [Theory]
        [InlineData(398, VehicleType.Common, 39.80, 7.96, 5, 100, 550.76)]
        [InlineData(501, VehicleType.Common, 50, 10.02, 10, 100, 671.02)]
        [InlineData(57, VehicleType.Common, 10, 1.14, 5, 100, 173.14)]
        [InlineData(1800, VehicleType.Luxury, 180, 72, 15, 100, 2167)]
        [InlineData(1100, VehicleType.Common, 50, 22, 15, 100, 1287)]
        [InlineData(1000000, VehicleType.Luxury, 200, 40000, 20, 100, 1040320)]
        public void CalculateTotalCost_ShouldReturnExpectedResult(decimal basePrice, VehicleType type, decimal basicFee, decimal specialFee, decimal associationFee, decimal storageFee, decimal expectedTotal)
        {
            // Arrange
            var vehicle = new Vehicle { BasePrice = basePrice, Type = type };

            // Act
            var result = _service.CalculateTotalCost(vehicle);

            // Assert
            Assert.Equal(basePrice, result.BasePrice);
            Assert.Equal(basicFee, result.BasicFee);
            Assert.Equal(specialFee, result.SpecialFee);
            Assert.Equal(associationFee, result.AssociationFee);
            Assert.Equal(storageFee, result.StorageFee);
            Assert.Equal(expectedTotal, result.TotalCost);
        }

       
    }
}
