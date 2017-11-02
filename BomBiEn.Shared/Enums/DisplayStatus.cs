using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomBiEn.Shared.Enums
{
    public enum DisplayStatus
    {
        [Description("CLOSED")]
        CLOSED = 0,

        [Description("PENDING")]
        PENDING = 1,

        [Description("APPROVED")]
        APPROVED = 2,        
    }
}