using LNK.Infrastructure.Commands;

namespace LNK.Commands.Agencies
{
    public class CreateAgencyCommand : AuditableCreateCommandBase
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string LogoUrl { get; set; }
    }
}