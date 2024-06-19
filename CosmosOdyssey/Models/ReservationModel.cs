
namespace CosmosOdyssey.Models
{
    public class ReservationModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RouteInfo Route { get; set; }
        public decimal TotalPrice { get; set; }
        public TimeSpan TravelTime { get; set; }
        public string CompanyName { get; set; }
    }
}
