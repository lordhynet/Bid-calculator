using BidCalculatorApi.Model;
using System.Collections.Generic;

namespace BidCalculator.IntegrationTest.TestData
{
    public static class FeeCalculatorTestData
    {
        public static IEnumerable<object[]> ValidFeeCalculationTestData()
        {
            yield return new object[]
            {
                new Vehicle { BasePrice = 398, Type = VehicleType.Common },
                new FeeCalculationResult
                {
                    BasePrice = 398,
                    BasicFee = 39.80m,
                    SpecialFee = 7.96m,
                    AssociationFee = 5,
                    StorageFee = 100,
                    TotalCost = 550.76m
                }
            };

            yield return new object[]
            {
                new Vehicle { BasePrice = 501, Type = VehicleType.Common },
                new FeeCalculationResult
                {
                    BasePrice = 501,
                    BasicFee = 50,
                    SpecialFee = 10.02m,
                    AssociationFee = 10,
                    StorageFee = 100,
                    TotalCost = 671.02m
                }
            };

            yield return new object[]
            {
                new Vehicle { BasePrice = 57, Type = VehicleType.Common },
                new FeeCalculationResult
                {
                    BasePrice = 57,
                    BasicFee = 10,
                    SpecialFee = 1.14m,
                    AssociationFee = 5,
                    StorageFee = 100,
                    TotalCost = 173.14m
                }
            };

            yield return new object[]
            {
                new Vehicle { BasePrice = 1800, Type = VehicleType.Luxury },
                new FeeCalculationResult
                {
                    BasePrice = 1800,
                    BasicFee = 180,
                    SpecialFee = 72,
                    AssociationFee = 15,
                    StorageFee = 100,
                    TotalCost = 2167
                }
            };

            yield return new object[]
            {
                new Vehicle { BasePrice = 1100, Type = VehicleType.Common },
                new FeeCalculationResult
                {
                    BasePrice = 1100,
                    BasicFee = 50,
                    SpecialFee = 22,
                    AssociationFee = 15,
                    StorageFee = 100,
                    TotalCost = 1287
                }
            };

            yield return new object[]
            {
                new Vehicle { BasePrice = 1000000, Type = VehicleType.Luxury },
                new FeeCalculationResult
                {
                    BasePrice = 1000000,
                    BasicFee = 200,
                    SpecialFee = 40000,
                    AssociationFee = 20,
                    StorageFee = 100,
                    TotalCost = 1040320
                }
            };
        }

        public static IEnumerable<object[]> InvalidFeeCalculationTestData()
        {
            yield return new object[] { 1000, "InvalidType" };
            yield return new object[] { -100, "Common" };
        }
    }
}
