using Azure.Search.Documents.Models;
using Azure.Search.Documents;
using Azure;

namespace ONELLOTARJANNEST10178800CLDV6211POEPART1
{
    public class SearchService
    {
        private readonly SearchClient _searchClient;

        public SearchService(string serviceName, string indexName, string apiKey)
        {
            var endpoint = new Uri($"https://{serviceName}.search.windows.net");
            _searchClient = new SearchClient(endpoint, indexName, new AzureKeyCredential(apiKey));
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string query)
        {
            var options = new SearchOptions
            {
                IncludeTotalCount = true
            };

            var response = await _searchClient.SearchAsync<Product>(query, options);
            return response.Value.GetResults();
        }

        internal async Task<string?> SearchAsync(string query)
        {
            throw new NotImplementedException();
        }
    }

}
