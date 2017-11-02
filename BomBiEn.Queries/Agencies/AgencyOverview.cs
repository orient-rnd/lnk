using BomBiEn.Infrastructure.Queries;

namespace BomBiEn.Queries.Agencies
{
    public class AgencyOverview : AuditableEntityOverviewBase
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string LogoUrl { get; set; }
    }
}