using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.WebUtilities;
using LNK.Shared.Configs;

namespace LNK.AppServices.Core.Services
{
    public class AssetUrlResolver : IAssetUrlResolver
    {
        private readonly MediaConfig _mediaConfig;

        public AssetUrlResolver(IOptions<MediaConfig> mediaConfig)
        {
            _mediaConfig = mediaConfig.Value;
        }

        public string ResolveImageUrl(string imageUrl, int? width = default(int?), int? height = default(int?), string mode = "")
        {
            if (String.IsNullOrWhiteSpace(imageUrl))
            {
                return imageUrl;
            }

            if (imageUrl.StartsWith("http://") || imageUrl.StartsWith("https://"))
            {
                return imageUrl;
            }

            string resolvedImageUrl = _mediaConfig.MediaEndpoint + imageUrl;

            if (width != null)
            {
                resolvedImageUrl = SetQueryParameter(resolvedImageUrl, "width", width.Value.ToString());
            }

            if (height != null)
            {
                resolvedImageUrl = SetQueryParameter(resolvedImageUrl, "height", height.Value.ToString());
            }

            if (!String.IsNullOrEmpty(mode))
            {
                resolvedImageUrl = SetQueryParameter(resolvedImageUrl, "mode", mode);
            }

            return resolvedImageUrl;
        }

        public string SetQueryParameter(string url, string queryParameterName, string queryParameterValue)
        {
            var queryParameters = new Dictionary<string, string>();
            queryParameters[queryParameterName] = queryParameterValue;

            return QueryHelpers.AddQueryString(url, queryParameters);
        }
    }
}