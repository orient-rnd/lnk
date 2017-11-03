using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNK.Infrastructure.Domain;
using MongoDB.Driver;

namespace LNK.Infrastructure.MongoDb
{
    public interface IMongoDbLogsRepository : IMongoDbWriteRepository
    {
    }
}