using CosmosOdyssey.Models;
using Newtonsoft.Json;
using System.Collections;

namespace CosmosOdyssey.Services
{
    public class TravelPriceService
    {
        public async Task<TravelPriceModel> GetTravelRoutes()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://cosmos-odyssey.azurewebsites.net/api/v1.0/TravelPrices");
                response.EnsureSuccessStatusCode();

                var contentString = await response.Content.ReadAsStringAsync();
                var travelRoutes = JsonConvert.DeserializeObject<TravelPriceModel>(contentString);

                return travelRoutes;
            }
        }
    }
}
