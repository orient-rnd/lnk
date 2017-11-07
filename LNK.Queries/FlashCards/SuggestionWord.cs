using LNK.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Utilities;

namespace LNK.Queries.FlashCards
{
    public class SuggestionWord
    {
        public string Id { get; set; }

        public string EnglishContent { get; set; }

        public string VietnameseContent { get; set; }

        public List<string> LinkAudio { get; set; }

        public string Type { get; set; }

        public string ShortEnglishContent { get; set; }

        public List<string> IPAs { get; set; }

        public string DetailLinkUrl { get; set; }

        public SuggestionWord(string title, string englishContent, string vietnameseContent, List<string> linkAudio, string id, string type, List<string> ipas, string catId = null, string catName = null)
        {
            this.EnglishContent = englishContent;
            this.VietnameseContent = vietnameseContent;
            LinkAudio = new List<string>();
            if (linkAudio != null)
            {
                LinkAudio.AddRange(linkAudio);
            }
            this.Id = id;
            this.Type = type;
            this.ShortEnglishContent = null;
            this.IPAs = new List<string>();
            if (ipas == null)
            {
                this.IPAs.Add(string.Empty);
            }
            else
            {
                this.IPAs.AddRange(ipas);
            }
            if (!string.IsNullOrEmpty(catId))
            {
                this.DetailLinkUrl = string.Format("./practicespeakinglistening/{0}/{1}/{2}/{3}", UrlUtility.ConvertStringToUrl(catName), UrlUtility.ConvertStringToUrl(title), catId, id);
            }
        }
    }
}