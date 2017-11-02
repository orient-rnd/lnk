using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Domain;
using MongoDB.Driver;

namespace BomBiEn.Infrastructure.MongoDb
{
    public class MongoDbReadRepository : IMongoDbReadRepository
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDbReadRepository(string mongoDbConnectionString, string mongoDbDatabaseName = null)
        {
            Contract.Requires(!String.IsNullOrWhiteSpace(mongoDbConnectionString));

            if (String.IsNullOrWhiteSpace(mongoDbDatabaseName))
            {
                mongoDbDatabaseName = mongoDbConnectionString.Split(new char[] {'/'}, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
            }

            Contract.Assert(!String.IsNullOrWhiteSpace(mongoDbDatabaseName));

            IMongoClient mongoClient = new MongoClient(mongoDbConnectionString);
            _mongoDatabase = mongoClient.GetDatabase(mongoDbDatabaseName);
        }

        public IFindFluent<TDocument, TDocument> Find<TDocument>(FilterDefinition<TDocument> filter = null)
        {
            if (filter == null)
            {
                var builder = Builders<TDocument>.Filter;
                filter = builder.Empty;
            }

            return _mongoDatabase.GetCollection<TDocument>(typeof(TDocument).Name).Find(filter);
        }

        public Task<IAsyncCursor<TDocument>> FindAsync<TDocument>(FilterDefinition<TDocument> filter = null)
        {
            if (filter == null)
            {
                var builder = Builders<TDocument>.Filter;
                filter = builder.Empty;
            }

            return _mongoDatabase.GetCollection<TDocument>(typeof(TDocument).Name).FindAsync(filter);
        }

        public TDocument Get<TDocument>(string id) where TDocument : IAggregateRoot
        {
            return Find<TDocument>(Builders<TDocument>.Filter.Eq(it => it.Id, id)).FirstOrDefault();
        }
    }
}