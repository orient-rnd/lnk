using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LNK.Infrastructure.Connectors
{
    public class RestConnector : IRestConnector
    {
        private readonly HttpClient _client;

        public RestConnector()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public TResponse Get<TResponse>(string requestUrl, ConnectorOptions options = null)
        {
            //Send request GET with the requestUrl
            HttpResponseMessage responseMessage = _client.GetAsync(requestUrl).Result;

            //Retrieve result from ContentResponse
            TResponse result = ReadContentResponseAsAsync<TResponse>(responseMessage.Content);
            return result;
        }

        public TResponse Post<TData, TResponse>(string requestUrl, TData data, ConnectorOptions options = null)
        {
            //Add data to HttpContent
            HttpContent content = new JsonContent<TData>(data);

            //Send request POST with the requestUrl and data content
            var responseMessage = _client.PostAsync(requestUrl, content).Result;

            //Retrieve result from ContentResponse
            var result = ReadContentResponseAsAsync<TResponse>(responseMessage.Content);

            return result;
        }

        public async Task<HttpResponseMessage> PostAsync<TData>(string requestUrl, TData data, ConnectorOptions options = null)
        {
            //Add data to HttpContent
            HttpContent content = new JsonContent<TData>(data);

            //Send request POST with the requestUrl and data content
            return await _client.PostAsync(requestUrl, content);
        }

        public void SetConnectorOption(ConnectorOptions options)
        {
            if (null != options)
            {
                if (false == string.IsNullOrEmpty(options.UserAgentHeader))
                {
                    _client.DefaultRequestHeaders.Add("User-Agent", options.UserAgentHeader);
                }
            }
        }

        protected virtual TResponse ReadContentResponseAsAsync<TResponse>(HttpContent content)
        {
            var result = content.ReadAsStringAsync().Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(result);
        }
    }
}
