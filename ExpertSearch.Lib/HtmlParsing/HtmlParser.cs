using HtmlAgilityPack;

namespace ExpertSearch.Lib.HtmlParsing
{
    internal class HtmlParser
    {
        private string _staticHTMLPath = "/src/ExpertSearch/wwwroot";
        private string _url = string.Empty;

        public HtmlParser(string url)
        { 
            _url = url;
        }

        public List<string> GetH1Elements()
        {
            return GetElement("h1");
        }

        public List<string> GetH2Elements()
        {
            return GetElement("h2");
        }

        public List<string> GetH3Elements()
        {
            return GetElement("h3");
        }

        private List<string> GetElement(string element)
        {
            var uri = new Uri(_url);
            HtmlDocument doc = new();
            if (uri.Host.ToUpper() == "LOCALHOST" || uri.Host == "127.0.0.1")
            {
                doc.Load($"{_staticHTMLPath}{uri.AbsolutePath}");
            }
            else
            {
                HtmlWeb webDoc = new();
                doc = webDoc.Load(_url);
            }

            return doc.DocumentNode.Descendants(element).Select(nd => nd.InnerText).ToList();
        }
    }
}