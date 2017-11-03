using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.AppServices.Lnk.Models.Account
{
    public class ChangePasswordRequestModel
    {
        [Required]
        [MinLength(8)]
        public string CurrentPassword { get; set; }

        [Required]
        [MinLength(8)]
        public string NewPassword { get; set; }
    }
}