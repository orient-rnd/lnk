using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Domain.Users.Models
{
    public class PredefinedPermission
    {
        public PredefinedPermission(string id, string name, string groupName)
        {
            Id = id;
            Name = name;
            GroupName = groupName;
        }

        public string Id { get; protected set; }

        public string Name { get; protected set; }

        public string GroupName { get; protected set; }
    }
}
