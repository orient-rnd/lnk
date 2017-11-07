using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.AppServices.Lnk.Models.Home
{
    public class Team
    {
        public string Name { get; set; }

        public List<Profile> Profiles { get; set; }
    }
}
