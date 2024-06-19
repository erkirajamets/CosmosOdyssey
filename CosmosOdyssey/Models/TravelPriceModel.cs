using System.Numerics;

namespace CosmosOdyssey.Models
{
    public class TravelPriceModel
    {
        public Guid Id { get; set; }
        public DateTime ValidUntil { get; set; }
        public List<Leg> Legs { get; set; }
    }
}
