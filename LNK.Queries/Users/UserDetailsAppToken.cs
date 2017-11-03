using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.Queries.Users
{
    public class UserDetailsAppToken
    {
        public string UserId { get; set; }

        public string Token { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}