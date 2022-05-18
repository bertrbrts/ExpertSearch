using ExpertSearch.Lib;

namespace ExpertSearch.ViewModels
{
    public class ExpertViewModel
    {
        public Expert? Expert { get; set; }
        public List<Expert> Friends { get; set; } = new List<Expert>();
        public string SearchInput { get; set; }

        public static ExpertViewModel Factory(int id)
        {
            ExpertViewModel expertViewModel = new();
            expertViewModel.Expert = Lib.Data.DataService.GetAll<Expert>().FirstOrDefault(e => e.Id == id);

            return expertViewModel;
        }
    }
}