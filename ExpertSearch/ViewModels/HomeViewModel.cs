using ExpertSearch.Lib;
using System.ComponentModel.DataAnnotations;

namespace ExpertSearch.ViewModels
{
    public class HomeViewModel : IHomeViewModel
    {
        [Required]
        public string NameInput { get; set; }
        [Required]
        public string WebsiteURLInput { get; set; }
        public List<Expert> Experts { get; set; }

        public HomeViewModel Factory()
        {
            HomeViewModel viewModel = new HomeViewModel();
            viewModel.Experts = Lib.Data.DataService.GetAll<Expert>();
            return viewModel;
        }
    }
}
