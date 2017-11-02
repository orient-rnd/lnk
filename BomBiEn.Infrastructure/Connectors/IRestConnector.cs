using System.Net.Http;
using System.Threading.Tasks;

namespace BomBiEn.Infrastructure.Connectors
{
    public interface IRestConnector
    {
        TResponse Get<TResponse>(string requestUrl, ConnectorOptions options = null);

        TResponse Post<TData, TResponse>(string requestUrl, TData data, ConnectorOptions options = null);

        Task<HttpResponseMessage> PostAsync<TData>(string requestUrl, TData data, ConnectorOptions options = null);
    }
}
