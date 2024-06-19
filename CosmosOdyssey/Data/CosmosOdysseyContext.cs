using CosmosOdyssey.Models;
using Microsoft.EntityFrameworkCore;

namespace CosmosOdyssey.Data
{
    public class CosmosOdysseyContext : DbContext
    {
        public CosmosOdysseyContext(DbContextOptions<CosmosOdysseyContext> options) : base(options)
        {
        }

        public DbSet<ReservationModel> ReservationModel { get; set; } = default!;
    }
}