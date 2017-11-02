using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.AppServices.Lnk.Models.Account
{
    public class ResetPasswordModel
    {
        [Required]
        public string Token { get; set; }
        [Display(Name = "User name")]
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
