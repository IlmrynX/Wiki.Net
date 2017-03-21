using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wiki.Net.Model;

namespace Wiki.Net
{
    public class MediaWiki
    {
        public RestClient Client;

        public MediaWiki(string baseApiUrl)
        {
            Client = new RestClient(baseApiUrl);
        }

        public async Task<string> GetToken()
        {
            var response = await GetApiResult<TokenQuery>(Resources.CrsfToken);
            return response.tokens.csrftoken;
        }

        public async Task<Search> SearchExact(string query)
        {
            var response = await GetApiResult<SearchQuery>(string.Format(Resources.Search, query));
            return response.search.FirstOrDefault();
        }

        public async Task<string> GetWikiTextPreview(string pageName)
        {
            return await GetWikiTextSection(pageName, 0);
        }

        public async Task<string> GetWikiTextSection(string pageName, int section)
        {
            var response = await GetParseResult<Text>(string.Format(Resources.ParseSection, pageName, section, "wikitext"));
            return response.parse.text.Value;
        }

        public async Task<string> GetHtmlPreview(string pageName)
        {
            return await GetHtmlSection(pageName, 0);
        }

        public async Task<string> GetHtmlSection(string pageName, int section)
        {
            var response = await GetParseResult<Text>(string.Format(Resources.ParseSection, pageName, section, "text"));
            return response.parse.text.Value;
        }


        public async Task<List<Section>> GetSections(string pageName)
        {
            var request = await GetParseResult<List<Section>>(string.Format(Resources.Sections, pageName));
            return request.parse.sections;
        }

        private async Task<T> GetApiResult<T>(string query)
        {
            var request = query + "&format=json";
            var response = await Client.ExecuteAsyncGet<ApiResult<T>>(request);

            return response.batchcomplete == "" ? response.query : default(T);
        }

        private async Task<ParseResult> GetParseResult<T>(string query)
        {
            var request = query + "&format=json";
            var response = await Client.ExecuteAsyncGet<ParseResult>(request);

            return response;
        }
    }
}
