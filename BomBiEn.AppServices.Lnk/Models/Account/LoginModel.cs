using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.AppServices.Lnk.Models.Account
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [DisplayName("Remember me")]
        public bool RememberMe { get; set; }

        public LoginModel()
        {
            RememberMe = false;
        }
    }
}