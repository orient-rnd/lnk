using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Queries.Users;

namespace BomBiEn.AppServices.Core
{
    public interface IWorkContext
    {
        string CurrentCountry { get; set; }

        UserDetails CurrentUser { get; set; }
    }
}