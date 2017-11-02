using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomBiEn.Shared.Constants
{
    public static class AzureBlobNames
    {
        public static string GetSitesName()
        {
            return "sites";
        }

        public static string GetSiteName(string siteName)
        {
            return $"sites/{siteName}";
        }

        public static string GetThemesName(string siteName)
        {
            return $"sites/{siteName}/themes";
        }

        public static string GetThemeName(string siteName, string theme)
        {
            return $"sites/{siteName}/themes/{theme}";
        }

        public static string GetPagesName(string siteName)
        {
            return $"sites/{siteName}/pages";
        }

        public static string GetPageName(string siteName, string pageId)
        {
            return $"sites/{siteName}/pages/{pageId}";
        }
    }
}