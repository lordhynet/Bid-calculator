using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
namespace BidCalculator.IntegrationTest.Utilities
{
    public static class WebApplicationFactorySetup
    {
        public static HttpClient CreateClient()
        {
            var factory = new WebApplicationFactory<BidCalculatorApi.Program>();
            return factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }
    }
}
