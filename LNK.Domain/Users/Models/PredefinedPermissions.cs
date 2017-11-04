using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.Domain.Users.Models
{
    public class PredefinedPermissions
    {
        public static IEnumerable<PredefinedPermission> GetPredefinedPermissions()
        {
            return new List<PredefinedPermission>()
            {
            };
        }
    }
}