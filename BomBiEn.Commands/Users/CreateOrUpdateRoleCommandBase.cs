using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BomBiEn.Infrastructure.Commands;

namespace BomBiEn.Commands.Users
{
    public abstract class CreateOrUpdateRoleCommandBase : CommandBase
    {
        public string Id { get; set; }

        [Remote("IsNameAvailable", "Roles", ErrorMessage = "The name is aleady exists", AdditionalFields = "Id")]
        public string Name { get; set; }

        public IEnumerable<string> Permissions { get; set; }
    }
}