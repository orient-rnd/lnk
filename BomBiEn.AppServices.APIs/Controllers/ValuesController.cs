using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BomBiEn.Infrastructure.MongoDb;

namespace BomBiEn.AppServices.APIs.Controllers
{
    [Route("")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Redirect("/swagger/");
        }
    }
}
