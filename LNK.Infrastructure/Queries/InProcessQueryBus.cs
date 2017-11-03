using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace LNK.Infrastructure.Queries
{
    public class InProcessQueryBus : IQueryBus
    {
        private readonly IComponentContext _componentContext;

        public InProcessQueryBus(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public TQueryResult Send<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery
        {
            IQueryHandler<TQuery, TQueryResult> queryHandler = _componentContext.Resolve<IQueryHandler<TQuery, TQueryResult>>();
            Contract.Assert(queryHandler != null);

            return queryHandler.Handle(query);
        }
    }
}