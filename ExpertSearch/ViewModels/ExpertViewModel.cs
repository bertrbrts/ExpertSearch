using ExpertSearch.Lib;

namespace ExpertSearch.ViewModels
{
    public class ExpertViewModel
    {
        public Expert? Expert { get; set; }
        public List<Expert> Friends { get; set; } = new List<Expert>();
        public List<Expert> NotFriends { get; set; } = new List<Expert>();
        public string SearchInput { get; set; }

        public static ExpertViewModel Factory(int id)
        {
            var _allExperts = Lib.Data.DataService.GetAll<Expert>();
            ExpertViewModel expertViewModel = new();
            expertViewModel.Expert = _allExperts.FirstOrDefault(e => e.Id == id);
            expertViewModel.NotFriends = _allExperts.Where(e => e.Id != id).ToList();

            if (expertViewModel.Expert != null)
            {
                foreach (var fID in expertViewModel.Expert.FriendIDs)
                {
                    var friend = _allExperts.FirstOrDefault(e => e.Id == fID);
                    if (friend != null)
                    {
                        expertViewModel.Friends.Add(friend);
                        expertViewModel.NotFriends.Remove(friend);
                    }
                }
            }



            return expertViewModel;
        }
    }
}