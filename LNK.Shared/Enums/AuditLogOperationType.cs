using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNK.Shared.Enums
{
    /// <summary>
    /// Audit log operation type
    /// </summary>
    public enum AuditLogOperationType
    {
        /// <summary>
        /// Create
        /// </summary>
        [Description("Create")]
        Create = 0,

        /// <summary>
        /// Update
        /// </summary>
        [Description("Update")]
        Update = 1,

        /// <summary>
        /// Delete
        /// </summary>
        [Description("Delete")]
        Delete = 2
    }
}