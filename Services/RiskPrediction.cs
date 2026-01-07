using Danciu_Lavinia_Lab5.Models;
    using System;
    using System.Net.Http;
    using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace Danciu_Lavinia_Lab5.Services
{
    

    
        public class RiskPredictionService : IRiskPredictionService
        {
            private readonly HttpClient _httpClient;

            public RiskPredictionService(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

        public async Task<string> PredictRiskAsync(RiskInput input)
        {
            var response = await _httpClient.PostAsJsonAsync("/predict", input);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<RiskApiResponse>();

            return result.PredictedLabel; // "Moderate Risk"
        }

        private class RiskApiResponse
        {
            [JsonPropertyName("predictedLabel")]
            public string PredictedLabel { get; set; }
        }
    }
}
