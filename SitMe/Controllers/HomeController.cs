using System;
using System.Diagnostics;
using System.Threading.Tasks;
using DataAccessLibrary.Models;
using DataAccessLibrary.Repositories.Generic;
using DataAccessLibrary.Repositories.RestaurantRepo;
using DataAccessLibrary.Repositories.UserReservations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SitMe.Models;

namespace SitMe.Controllers {
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<User> _userRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IUserReservations _userReservations;

        public HomeController(
            ILogger<HomeController> logger,
            IRepository<User> userRepository,
            IRestaurantRepository restaurantRepository,
            IUserReservations userReservations)
        {
            _logger = logger;
            _userRepository = userRepository;
            _restaurantRepository = restaurantRepository;
            _userReservations = userReservations;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RestaurantProfile() {
            return View();
        }

        public async Task<IActionResult> RestaurantList() {
            // many to many query
            //var restaurants = await _restaurantRepository.GetRetaurantsWithTags("polish");
            var restaurants = await _restaurantRepository.GetRetaurantsWithTags(0, 9);

            return View(restaurants);
        }

        public async Task<IActionResult> RestaurantListFilter(string filterByTest) {
            var restaurants = await _restaurantRepository.GetRetaurantsWithTags(filterByTest);
            return PartialView("_RestaurantsList", restaurants);
            //return View(restaurants);
        }


        public IActionResult CreateReservation() {
            return View();
        }

        public async Task<IActionResult> UserProfile()
        {
            var currentUser = await _userRepository.GetById(Guid.Parse("8834320f-58d2-4a6c-8375-008055ee36bb"));
            //var currentUserReservations = await _userReservations.GetReservationsHistory(Guid.Parse("8834320f-58d2-4a6c-8375-008055ee36bb"));

            return View(currentUser);
        }

        public IActionResult ThankYou() {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
