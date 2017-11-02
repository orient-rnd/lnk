using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Infrastructure.TemplateEngines
{
    public interface ITemplateEngine
    {
        string Render<T>(string template, T templateModel);
    }
}