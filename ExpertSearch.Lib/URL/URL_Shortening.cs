using Bitly;

namespace ExpertSearch.Lib.URL
{
    public class URL_Shortening
    {
        public static string GetShortURL(int? port, string apiKey, string longURL)
        {
            var uri = new Uri(longURL);

            string _port = string.Empty;
            if (port != null && (uri.Host.ToUpper() == "LOCALHOST" || uri.Host == "127.0.0.1"))
                _port = $":{port}";

            string formattedURL = $"{uri.Scheme}://{uri.Host}{_port}{uri.AbsolutePath}";
            BitlyService bitlyService = new(apiKey);
            return bitlyService.Shorten(formattedURL).Result.Data.Url;
        }
    }
}