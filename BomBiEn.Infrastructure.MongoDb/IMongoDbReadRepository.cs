using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Domain;
using MongoDB.Driver;

namespace BomBiEn.Infrastructure.MongoDb
{
    public interface IMongoDbReadRepository
    {
        IFindFluent<TDocument, TDocument> Find<TDocument>(FilterDefinition<TDocument> filter = null);

        Task<IAsyncCursor<TDocument>> FindAsync<TDocument>(FilterDefinition<TDocument> filter = null);

        TDocument Get<TDocument>(string id) where TDocument : IAggregateRoot;
    }
}