using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.Infrastructure.Queries
{
    public interface IPagedQueryResult
    {
        long TotalItemCount { get; }

        int Page { get; }

        int PageSize { get; }

        int PageCount { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }

        int StartItemIndex { get; }

        int EndItemIndex { get; }
    }
}