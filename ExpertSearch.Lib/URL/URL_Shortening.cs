using Bitly;

namespace ExpertSearch.Lib.URL
{
    public class URL_Shortening
    {
        public static string GetShortURL(string apiKey, string longURL)
        {
            BitlyService bitlyService = new(apiKey);
            return bitlyService.Shorten(longURL).Result.Data.Url;
        }
    }
}