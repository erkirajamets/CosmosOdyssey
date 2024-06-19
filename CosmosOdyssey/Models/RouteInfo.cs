namespace CosmosOdyssey.Models
{
    public class RouteInfo
    {
        public Guid Id { get; set; }
        public Planet From { get; set; }
        public Planet To { get; set; }
        public long Distance { get; set; }
        public Guid FromId { get; set; }
        public Guid ToId { get; set; }
    }
}
