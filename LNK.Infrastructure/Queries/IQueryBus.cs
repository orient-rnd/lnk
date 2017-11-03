using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNK.Infrastructure.Queries
{
    public interface IQueryBus
    {
        TQueryResult Send<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery;
    }
}