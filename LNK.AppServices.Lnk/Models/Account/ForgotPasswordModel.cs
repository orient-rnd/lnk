using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.AppServices.Lnk.Models.Account
{
    public class ForgotPasswordModel
    {
        [Display(Name = "User name")]
        [Required]
        public string UserName { get; set; }
    }
}