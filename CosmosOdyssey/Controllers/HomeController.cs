using CosmosOdyssey.Models;
using CosmosOdyssey.Services;
using CosmosOdyssey.Views.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CosmosOdyssey.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TravelPriceService _travelPriceService;
        private readonly ReservationService _reservationService;
        private static readonly List<string> Planets = new List<string>
        {
            "Mercury",
            "Venus",
            "Earth",
            "Mars",
            "Jupiter",
            "Saturn",
            "Uranus",
            "Neptune" 
        };


        public HomeController(ILogger<HomeController> logger, TravelPriceService travelPriceService, ReservationService reservationService)
        {
            _logger = logger;
            _travelPriceService = travelPriceService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Planets = Planets
            };
            return View(model);
        }

        public async Task<IActionResult> SearchRoutes(string origin, string destination)
        {
			TravelPriceModel travelPrice = await _travelPriceService.GetTravelRoutes();
			Leg leg = travelPrice.Legs.FirstOrDefault(x => x.RouteInfo.From.Name == origin && x.RouteInfo.To.Name == destination);

			var model = new HomeViewModel
            {
                Planets = Planets,
                Leg = leg
            };
            return View("Index", model);
        }
        public IActionResult MyReservations()
        {
            var model = _reservationService.GetAllReservations();
            return View(model);
        }
        public async Task<IActionResult> CreateReservation(Guid legId,Guid providerId, string firstName, string lastName)
        {
            var leg = (await _travelPriceService.GetTravelRoutes()).Legs.FirstOrDefault(x => x.Id == legId);
            if(leg == null)
            {
                return View("Index");
            }
            var provider = leg.Providers.First(x => x.Id == providerId);
            ReservationModel reservation = new ReservationModel()
            {
                Id = Guid.NewGuid(),
                CompanyName = provider.Company.Name,
                FirstName = firstName,
                LastName = lastName,
                Route = leg.RouteInfo,
                TotalPrice = provider.Price,
                TravelTime = provider.TravelTime,

            };
            _reservationService.AddReservation(reservation);
            return View(MyReservations());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
