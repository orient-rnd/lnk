﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BomBiEn.Infrastructure.Commands;

namespace BomBiEn.Commands.Emails
{
    public class CreateEmailTemplateCategoryCommand : AuditableCreateCommandBase
    {
        public string Name { get; set; }

        [Remote("IsCodeAvailable", "EmailTemplateCategories", ErrorMessage = "The code is aleady exists", AdditionalFields = "Id")]
        public string Code { get; set; }
    }
}