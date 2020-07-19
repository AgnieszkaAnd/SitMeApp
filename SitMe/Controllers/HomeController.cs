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

        public HomeController(ILogger<HomeController> logger, IRepository<User> userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;  
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAll();
            var user = await _userRepository.GetById(new Guid("a8a5bcb8-e2c4-4fac-838b-248d0612ca34"));
            user.FirstName = "Honorat" + users.Count.ToString();
            await _userRepository.Update(user);
            users[^1].FirstName = "test";
            users[^1].Id = Guid.NewGuid();
            await _userRepository.Insert(users[^1]);
            //await _userRepository.DeleteById(users[^1].Id);
            return View(user);
        }

        public IActionResult RestaurantProfile() {
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
