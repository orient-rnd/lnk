using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.AppServices.Core
{
    public interface IWorkContextProvider
    {
        IWorkContext GetWorkContext();

        void SetWorkContext(IWorkContext workContext);
    }
}