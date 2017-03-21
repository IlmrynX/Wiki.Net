using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Wiki.Net
{
    public class RestClient
    {
        public string BaseUrl { get; }

        public RestClient(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public async Task<T> ExecuteAsyncGet<T>(string request)
        {
            return await DownloadObjectAsync<T>(request);
        }

        internal async Task<T> DownloadObjectAsync<T>(string url)
        {
            try
            {
                string response = await GetStringAsync(BaseUrl + "/" + url);
                string responseString = response;
                return JsonConvert.DeserializeObject<T>(responseString);
            }
            catch
            {
                return default(T);
            }
        }

        private static async Task<string> GetStringAsync(string url)
        {
            var request = new HttpClient();
            return await request.GetStringAsync(url);
        }
    }
}