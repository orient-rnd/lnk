using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LNK.Shared.Enums;

namespace LNK.AppServices.Lnk.Models.Account
{
    public class SignUpRequestModel
    {        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }        
    }
}