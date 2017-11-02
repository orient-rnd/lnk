using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BomBiEn.AppServices.Core
{
    public class WorkContextProvider : IWorkContextProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WorkContextProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IWorkContext GetWorkContext()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var workContext = httpContext.Items["WorkContext"];
            return workContext as IWorkContext;
        }

        public void SetWorkContext(IWorkContext workContext)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            httpContext.Items["WorkContext"] = workContext;
        }
    }
}