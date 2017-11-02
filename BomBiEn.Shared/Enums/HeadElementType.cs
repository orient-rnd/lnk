using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomBiEn.Shared.Enums
{
    /// <summary>
    /// Head element type
    /// </summary>
    public enum HeadElementType
    {
        /// <summary>
        /// Meta
        /// </summary>
        [Description("Meta")]
        Meta = 0,

        /// <summary>
        /// Title
        /// </summary>
        [Description("Title")]
        Title = 1,

        /// <summary>
        /// Link
        /// </summary>
        [Description("Link")]
        Link = 2,

        /// <summary>
        /// Script
        /// </summary>
        [Description("Script")]
        Script = 3
    }
}