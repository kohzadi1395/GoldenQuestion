using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Interfaces.General;
using MongoDB.Driver;

namespace Persistence.Core
{
    public class MongoRepository<T> : IMongoRepository<T>
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(IMongoClient mongoClient, string databaseName, string collectionName)
        {
            var database = mongoClient.GetDatabase(databaseName);
            _collection = database.GetCollection<T>(collectionName);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> criteria)
        {
            if (criteria == null) 
                return null;

            var findFluent = _collection.Find(criteria);
            return findFluent?.ToList();

        }

        public async void Add(T entity, Expression<Func<T, bool>> predicate = null)
        {
            try
            {
                if (predicate == null)
                {
                    await _collection.InsertOneAsync(entity);
                    return;
                }

                var exists = Find(predicate).Any();
                if (exists == false)
                    await _collection.InsertOneAsync(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _collection.InsertManyAsync(entities);
        }

        public Task<long> Count(Expression<Func<T, bool>> predicate)
        {
            return predicate != null ? _collection.CountDocumentsAsync(predicate) : throw new NullReferenceException();
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return Find(predicate).FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return Find(predicate);
        }

        public void Remove(T entity)
        {
            //_collection.FindOneAndDelete(x => x.Id == entity.Id);
        }

        public void RemoveRange(Expression<Func<T, bool>> predicate)
        {
            _collection.DeleteMany(predicate);
        }


        public void Replace(T entity, Expression<Func<T, bool>> predicate)
        {
            _collection.FindOneAndReplace(predicate, entity);
        }

        //var mongoClient = new MongoClient();
        //var database = mongoClient.GetDatabase("sample_geospatial");
        //var collection = database.GetCollection<ShipWreck>("shipwrecks");
        //var filter = "{price:{$gt:400}}";
        //---------------------------------
        //var filter = "{$and:[price:{$gt:400}},price:{lt:600}}]}";
        //---------------------------------
        //var filter = new BsonDocument("price",new BsonArray
        //{
        //    new BsonDocument("price",
        //    new BsonDocument("$gt", 400)),
        //    new BsonDocument("price",
        //        new BsonDocument("lt", 600)),
        //});
        //---------------------------------
        //var builder = Builders<BsonDocument>.Filter;
        //var filter = builder.Gt("price", 400) & builder.Lt("price", 600);
        //---------------------------------
        //collection.Find(filter);
    }
}