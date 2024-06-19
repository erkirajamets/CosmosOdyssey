using CosmosOdyssey.Models;

namespace CosmosOdyssey.Views.Home
{
    public class HomeViewModel
    {
        public List<string> Planets { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public RouteInfo Route { get; set; }

		public Leg Leg { get; set; }
		public List<Provider> Providers { get; set; }

    }
}
