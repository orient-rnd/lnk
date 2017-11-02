using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Http;
using BomBiEn.Infrastructure.Commands;

namespace BomBiEn.AppServices.Lnk.Services
{
    public class AdminPanelCommandBus : InProcessCommandBus
    {
        private readonly IComponentContext _componentContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminPanelCommandBus(IComponentContext componentContext, IHttpContextAccessor httpContextAccessor)
            : base(componentContext)
        {
            _componentContext = componentContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public override void Send<TCommand>(TCommand command)
        {
            if (command is IAuditableCreateCommand)
            {
                (command as IAuditableCreateCommand).CreatedDate = DateTime.UtcNow;
                (command as IAuditableCreateCommand).CreatedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            }

            if (command is IAuditableUpdateCommand)
            {
                (command as IAuditableUpdateCommand).ModifiedDate = DateTime.UtcNow;
                (command as IAuditableUpdateCommand).ModifiedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            }

            if (command is AuditableDeleteCommandBase)
            {
                (command as AuditableDeleteCommandBase).DeletedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            }

            base.Send<TCommand>(command);
        }
    }
}