namespace BomBiEn.Infrastructure.Connectors
{
    public class ConnectorOptions
    {
        public string UserAgentHeader { get; set; }
        public ConnectorOptions(string userAgent = null)
        {
            this.UserAgentHeader = userAgent;
        }
    }
}
