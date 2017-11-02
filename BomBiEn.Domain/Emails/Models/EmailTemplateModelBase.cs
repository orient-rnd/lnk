using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomBiEn.Domain.Emails.Models
{
    /// <summary>
    /// Email template model base
    /// </summary>
    public abstract class EmailTemplateModelBase
    {
        /// <summary>
        /// Language code
        /// </summary>
        public string LanguageCode { get; set; }

        /// <summary>
        /// From email address
        /// </summary>
        public string FromEmailAddress { get; set; }

        /// <summary>
        /// From display name
        /// </summary>
        public string FromDisplayName { get; set; }

        /// <summary>
        /// To email address
        /// </summary>
        public string ToEmailAddress { get; set; }

        /// <summary>
        /// To display name
        /// </summary>
        public string ToDisplayName { get; set; }
    }
}