using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BidCalculatorApi.Model
{
    public class Vehicle
    {
        [Range(0.01, double.MaxValue, ErrorMessage = "BasePrice must be greater than zero.")]
        public decimal BasePrice { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [Required]
        public VehicleType Type { get; set; }
    }
}
