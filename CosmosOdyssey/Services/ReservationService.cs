using CosmosOdyssey.Models;

namespace CosmosOdyssey.Services
{
    public class ReservationService
    {
        private List<ReservationModel> reservations = new List<ReservationModel>();

        public void AddReservation(ReservationModel reservation)
        {
            reservations.Add(reservation);
        }

        public List<ReservationModel> GetAllReservations()
        {
            return reservations;
        }
    }
}
