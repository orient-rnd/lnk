using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Queries.Users;

namespace BomBiEn.AppServices.Core
{
    public class WorkContext : IWorkContext
    {
        public virtual string CurrentCountry { get; set; }

        public virtual UserDetails CurrentUser { get; set; }
    }
}