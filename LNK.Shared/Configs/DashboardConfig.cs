namespace LNK.Shared.Configs
{
    /// <summary>
    /// Define the Dashboard config.
    /// </summary>
    public class DashboardConfig
    {
        /// <summary>
        /// Gets or sets the Dashboard Impersonation Endpoint.
        /// </summary>
        public string DashboardImpersonationEndpoint { get; set; }


        /// <summary>
        /// Gets or sets the Expiry Time of Token.
        /// </summary>
        public int NumberOfExpirationDays { get; set; }        
    }
}