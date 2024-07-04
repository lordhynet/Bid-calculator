using BidCalculatorApi.Model;
using BidCalculatorApi.Services.Interfaces;

namespace BidCalculatorApi.Services.Implementations
{
    public class FeeCalculatorService : IFeeCalculatorService
    {
        public FeeCalculationResult CalculateTotalCost(Vehicle vehicle)
        {
          

            var result = new FeeCalculationResult
            {
                BasePrice = vehicle.BasePrice,
                BasicFee = CalculateBasicFee(vehicle),
                SpecialFee = CalculateSpecialFee(vehicle),
                AssociationFee = CalculateAssociationFee(vehicle.BasePrice),
                StorageFee = 100m
            };
            result.TotalCost = result.BasePrice + result.BasicFee + result.SpecialFee + result.AssociationFee + result.StorageFee;
            return result;
        }

        private decimal CalculateBasicFee(Vehicle vehicle)
        {
            decimal basicFee = vehicle.BasePrice * 0.1m;
            if (vehicle.Type == VehicleType.Common)
            {
                basicFee = Math.Clamp(basicFee, 10m, 50m);
            }
            else if (vehicle.Type == VehicleType.Luxury)
            {
                basicFee = Math.Clamp(basicFee, 25m, 200m);
            }
            return basicFee;
        }

        private decimal CalculateSpecialFee(Vehicle vehicle)
        {
            decimal specialFee = vehicle.BasePrice * (vehicle.Type == VehicleType.Common ? 0.02m : 0.04m);
            return specialFee;
        }

        private decimal CalculateAssociationFee(decimal basePrice)
        {
            if (basePrice <= 500m) return 5m;
            if (basePrice <= 1000m) return 10m;
            if (basePrice <= 3000m) return 15m;
            return 20m;
        }
    }
}