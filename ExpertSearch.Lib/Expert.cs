namespace ExpertSearch.Lib
{
    public class Expert
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Heading1 { get; set; }
        public string Heading2 { get; set; }
        public string Heading3 { get; set; }
        public string WebSiteLongURL { get; set; }
        public string WebSiteShortURL { get; set; }

        public Expert() { }
        public Expert(string name, string url)
        {
            Id = 1;
            FirstName = name.Split(' ')[0];
            LastName = name.Split(' ')[1];
            WebSiteLongURL = url;
        }
    }
}