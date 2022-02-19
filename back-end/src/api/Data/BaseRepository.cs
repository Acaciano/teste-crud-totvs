using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cbyk.ATS.API.Data.Interface;
using Cbyk.ATS.API.Models;

namespace Cbyk.ATS.API.Data
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : EntityModel
    {
        protected readonly IMongoCollection<TEntity> DbSet;
        protected readonly MongoClient _mongoClient;

        protected BaseRepository(IConfiguration configuration, string collectionName)
        {
            string connection = configuration.GetValue<string>("MongoSettings:Connection");
            string databaseName = configuration.GetValue<string>("MongoSettings:DatabaseName");

            _mongoClient = new MongoClient(connection);
            IMongoDatabase db = _mongoClient.GetDatabase(databaseName);

            DbSet = db.GetCollection<TEntity>(collectionName);
        }

        public virtual Task Add(TEntity obj)
        {
            return DbSet.InsertOneAsync(obj);
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return data.FirstOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public virtual Task Update(Guid key, TEntity newEntity)
        {
            return DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Where(x => x.Id == key), newEntity);
        }

        public virtual Task Remove(Guid id)
        {
            return DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
