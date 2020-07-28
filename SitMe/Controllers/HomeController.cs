using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLibary.Models;
using DataAccessLibary.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SitMe.Models;

namespace SitMe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Restaurant> _restaurantRepository;

        public HomeController(  ILogger<HomeController> logger,
                                IRepository<User> userRepository,
                                IRepository<Restaurant> restaurantRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _restaurantRepository = restaurantRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult RestaurantProfile() {
            return View();
        }

        public async Task<IActionResult> RestaurantList() {
            // many to many query
            var restaurants = await _restaurantRepository.GetAllRestaurantsJoinedTags();
            return View(restaurants);
        }


        public IActionResult CreateReservation() {
            return View();
        }

        public IActionResult ThankYou() {
            return View();
        }

        public IActionResult Privacy()
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
