using LNK.Infrastructure.Queries;

namespace LNK.Queries.Agencies
{
    public class GetAgencyDetailsQuery : QueryBase
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string LogoUrl { get; set; }
    }
}