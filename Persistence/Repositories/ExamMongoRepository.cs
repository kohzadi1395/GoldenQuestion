using Application.DTOs;
using Application.Interfaces.ExmDto;
using MongoDB.Driver;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class ExamMongoRepository : MongoRepository<ExamMongo>, IExamMongoRepository
    {
        public ExamMongoRepository(IMongoClient mongoClient, string databaseName, string collectionName) : base(
            mongoClient, databaseName, collectionName)
        {
        }
    }
}