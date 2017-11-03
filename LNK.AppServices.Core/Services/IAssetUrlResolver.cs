using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.AppServices.Core.Services
{
    public interface IAssetUrlResolver
    {
        string ResolveImageUrl(string imageUrl, int? width = null, int? height = null, string mode = "");
    }
}