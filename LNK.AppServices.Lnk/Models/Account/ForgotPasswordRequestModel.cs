using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.AppServices.Lnk.Models.Account
{
    public class ForgotPasswordRequestModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
