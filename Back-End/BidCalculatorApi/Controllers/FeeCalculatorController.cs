using BidCalculatorApi.Model;
using BidCalculatorApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeeCalculatorController : ControllerBase
    {
        private readonly IFeeCalculatorService _feeCalculatorService;

        public FeeCalculatorController(IFeeCalculatorService feeCalculatorService)
        {
            _feeCalculatorService = feeCalculatorService;
        }

        [HttpPost]
        [Route("CalculateTotalCost")]
        public ActionResult<FeeCalculationResult> CalculateTotalCost(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _feeCalculatorService.CalculateTotalCost(vehicle);
            return Ok(result);

           
        }
    }
}

