using ExpertSearch.Lib;
using ExpertSearch.Models;
using ExpertSearch.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExpertSearch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeViewModel _homeViewModel;

        public HomeController(ILogger<HomeController> logger, IHomeViewModel homeViewModel)
        {
            _logger = logger;
            _homeViewModel = homeViewModel;
        }

        public IActionResult Index()
        {
            var viewModel = _homeViewModel.Factory();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddExpert(HomeViewModel homeViewModel)
        {
            Expert exp = new(homeViewModel.NameInput, homeViewModel.WebsiteURLInput);
            Lib.Data.DataService.Add<Expert>(exp);

            homeViewModel.Experts = Lib.Data.DataService.GetAll<Expert>();

            return View("Index", homeViewModel);
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