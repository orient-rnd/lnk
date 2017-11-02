using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Infrastructure.PdfGenerator
{
    public interface IPdfGeneratorService
    {
        byte[] GeneratePdf(string htmlBody, string PathOfwkhtmltopdfExecuteFile);
        byte[] GeneratePdf(string htmlHeader, string htmlBody, string PathOfwkhtmltopdfExecuteFile);
    }
}
