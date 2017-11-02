using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.DotNet.Tools.Common;
using System.Diagnostics;
using System.IO;

namespace BomBiEn.Infrastructure.PdfGenerator
{
    public class PdfGeneratorService : IPdfGeneratorService
    {
        /// <summary>
        /// Generate pdf
        /// </summary>
        /// <param name="htmlBody"></param>
        /// <returns></returns>
        public byte[] GeneratePdf(string htmlBody, string PathOfwkhtmltopdfExecuteFile)
        {
            byte[] bytes = null;
            if (!string.IsNullOrWhiteSpace(htmlBody))
            {
                string exeFilePath = Directory.GetCurrentDirectory();
                var startInfo = new ProcessStartInfo();
                startInfo.FileName = PathOfwkhtmltopdfExecuteFile;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.Arguments = "-q -n " + " - -";

                using (Process p = Process.Start(startInfo))
                {
                    using (StreamWriter sw = p.StandardInput)
                    {
                        sw.AutoFlush = true;
                        //sw.Write(String.Format(@"<!DOCTYPE html><html><head><meta charset = ""UTF-8"" /></head><body>{0}</body></html>", htmlBody));
                        sw.Write(htmlBody);
                    }

                    using (var memstream = new MemoryStream())
                    {
                        p.StandardOutput.BaseStream.CopyTo(memstream);
                        bytes = memstream.ToArray();
                    }
                    p.WaitForExit();
                }
            }

            return bytes;
        }

        public byte[] GeneratePdf(string htmlHeader, string htmlBody, string PathOfwkhtmltopdfExecuteFile)
        {
            byte[] bytes = null;
            if (!string.IsNullOrWhiteSpace(htmlBody))
            {
                string exeFilePath = Directory.GetCurrentDirectory();
                var startInfo = new ProcessStartInfo();
                startInfo.FileName = PathOfwkhtmltopdfExecuteFile;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.Arguments = "-q -n " + " - -";

                using (Process p = Process.Start(startInfo))
                {
                    using (StreamWriter sw = p.StandardInput)
                    {
                        sw.AutoFlush = true;
                        sw.Write(String.Format(@"<!DOCTYPE html><html><head>{0}</head><body>{1}</body></html>", htmlHeader, htmlBody));
                    }

                    using (var memstream = new MemoryStream())
                    {
                        p.StandardOutput.BaseStream.CopyTo(memstream);
                        bytes = memstream.ToArray();
                    }
                    p.WaitForExit();
                }
            }

            return bytes;
        }
    }
}