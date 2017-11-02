﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Commands;

namespace BomBiEn.Commands.Emails
{
    public class CreateEmailTemplateCommand : CreateOrUpdateEmailTemplateCommand, IAuditableCreateCommand
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}