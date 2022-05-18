using ExpertSearch.Lib.HtmlParsing;
using ExpertSearch.Lib.URL;

namespace ExpertSearch.Lib
{
    public class Expert
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Heading1 { get; set; }
        public List<string> Heading2 { get; set; }
        public List<string> Heading3 { get; set; }
        public string WebSiteLongURL { get; set; }
        public string WebSiteShortURL { get; set; }

        private HtmlParser _parser;

        public Expert() { }
        public Expert(int? port, string bitlyAPIKey, string name, string url)
        {
            var uri = new Uri(url);

            string _port = string.Empty;
            if (port != null && (uri.Host.ToUpper() == "LOCALHOST" || uri.Host == "127.0.0.1"))
                _port = $":{port}";

            string formattedURL = $"{uri.Scheme}://{uri.Host}{_port}{uri.AbsolutePath}";

            _parser = new HtmlParser(formattedURL);

            Id = 1;
            FirstName = name.Split(' ')[0];
            LastName = name.Split(' ')[1];
            WebSiteLongURL = url;

            WebSiteShortURL = URL_Shortening.GetShortURL(bitlyAPIKey, formattedURL);
            Heading1 = _parser.GetH1Elements();
            Heading2 = _parser.GetH2Elements();
            Heading3 = _parser.GetH3Elements();
        }
    }
}