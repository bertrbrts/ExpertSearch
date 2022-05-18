using ExpertSearch.Lib;

namespace ExpertSearch.ViewModels
{
    public interface IHomeViewModel
    {
        List<Expert> Experts { get; set; }
        string NameInput { get; set; }
        string WebsiteURLInput { get; set; }
        HomeViewModel Factory();
    }
}