using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Domain;
using MongoDB.Driver;

namespace LNK.Infrastructure.MongoDb
{
    public class MongoDbLogsRepository : MongoDbWriteRepository, IMongoDbLogsRepository
    {
        public MongoDbLogsRepository(string mongoDbConnectionString, string mongoDbDatabaseName = null)
            : base(mongoDbConnectionString, mongoDbDatabaseName)
        {
        }
    }
}