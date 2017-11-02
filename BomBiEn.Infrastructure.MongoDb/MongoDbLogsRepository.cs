using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Domain;
using MongoDB.Driver;

namespace BomBiEn.Infrastructure.MongoDb
{
    public class MongoDbLogsRepository : MongoDbWriteRepository, IMongoDbLogsRepository
    {
        public MongoDbLogsRepository(string mongoDbConnectionString, string mongoDbDatabaseName = null)
            : base(mongoDbConnectionString, mongoDbDatabaseName)
        {
        }
    }
}