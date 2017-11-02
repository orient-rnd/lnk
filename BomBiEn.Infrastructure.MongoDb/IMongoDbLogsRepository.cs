using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Domain;
using MongoDB.Driver;

namespace BomBiEn.Infrastructure.MongoDb
{
    public interface IMongoDbLogsRepository : IMongoDbWriteRepository
    {
    }
}