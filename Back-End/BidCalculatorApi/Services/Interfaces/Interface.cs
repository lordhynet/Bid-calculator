using BidCalculatorApi.Model;

namespace BidCalculatorApi.Services.Interfaces
{
    public interface IFeeCalculatorService
    {
        FeeCalculationResult CalculateTotalCost(Vehicle vehicle);
    }
}
