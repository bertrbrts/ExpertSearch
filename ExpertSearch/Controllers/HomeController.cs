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
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var apiKey = config.GetValue<string>("BitlyApiKey");
            Expert exp = new(Request.Host.Port, apiKey, homeViewModel.NameInput, homeViewModel.WebsiteURLInput);
            Lib.Data.DataService.Add<Expert>(exp);

            homeViewModel.Experts = Lib.Data.DataService.GetAll<Expert>();

            return View("Index", homeViewModel);
        }

        [HttpPost]
        public IActionResult SearchExpert(ExpertViewModel expertViewModel, int id)
        {
            ExpertViewModel newExpVM = ExpertViewModel.Factory(id);

            var allExperts = Lib.Data.DataService.GetAll<Expert>();
            var currentExpert = newExpVM.Expert;

            string searchString = expertViewModel.SearchInput.ToUpper();
             
            var result = allExperts.FirstOrDefault(x => 
                x.Heading1.Any(h => h.ToUpper().Contains(searchString)) ||
                x.Heading2.Any(h => h.ToUpper().Contains(searchString)) ||
                x.Heading3.Any(h => h.ToUpper().Contains(searchString)));

            if (result != null)
            {
                newExpVM.ExpertSearchResult = result;

                var dupes = result.FriendIDs.Intersect(newExpVM.Expert.FriendIDs);
                if (dupes.Any())
                {
                    foreach (var d in dupes)
                    {
                        var mutFriend = allExperts.FirstOrDefault(e => e.Id == d);
                        if (mutFriend != null)
                            newExpVM.MutualFriends.Add(mutFriend);
                    }
                }
            }

            return View("ExpertView", newExpVM);
        }

        public IActionResult ViewProfile(int id)
        {
            ExpertViewModel expertViewModel = ExpertViewModel.Factory(id);
            return View("ExpertView", expertViewModel);
        }

        public IActionResult AddFriend(int expertID, int friendID)
        {
            var allExperts = Lib.Data.DataService.GetAll<Expert>();
            Expert? expert = allExperts.FirstOrDefault(e => e.Id == expertID);
            if (expert != null)
            {
                expert.FriendIDs.Add(friendID);
                Lib.Data.DataService.Update(expertID, expert);
            }

            Expert? friend = allExperts.FirstOrDefault(e => e.Id == friendID);
            if (friend != null)
            {
                friend.FriendIDs.Add(expertID);
                Lib.Data.DataService.Update(friendID, friend);
            }

            ExpertViewModel expertViewModel = ExpertViewModel.Factory(expertID);

            return View("ExpertView", expertViewModel);
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