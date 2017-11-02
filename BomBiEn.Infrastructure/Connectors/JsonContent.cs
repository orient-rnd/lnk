using System.Text;

namespace BomBiEn.Infrastructure.Connectors
{
    public class JsonContent<T> : System.Net.Http.StringContent
    {
        public JsonContent(T data) : base(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")
        {
        }
    }
}
