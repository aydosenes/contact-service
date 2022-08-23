﻿using Application.Interfaces.Repository;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public abstract class BaseMongoRepository<T> : BaseRepository<T>, IBaseMongoRepository<T> where T : BaseEntity, new()
    {
        protected BaseMongoRepository(string connectionString, string databaseName, string collectionName) : base(connectionString, databaseName, collectionName)
        {
        }

        public virtual async Task<ICollection<T>> GetListAsync()
        {
            return await _collection.Find(s => s.IsDeleted == false).ToListAsync();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public virtual async Task AddRangeAsync(ICollection<T> entities)
        {
            await _collection.InsertManyAsync(entities);
        }

        public virtual async Task DeleteAsync(T entity)
        {
            var filter = Builders<T>.Filter.Where(s => s.Id.Equals(entity.Id) && s.IsDeleted == false);
            var update = Builders<T>.Update.Set("IsDeleted", "true");
            await _collection.UpdateOneAsync(filter, update);
        }

        public virtual async Task DeleteRangeAsync(ICollection<T> entities)
        {
            var filter = Builders<T>.Filter.Where(s => entities.Contains(s) && s.IsDeleted == false);
            var update = Builders<T>.Update.Set("IsDeleted", "true");
            await _collection.UpdateManyAsync(filter, update);
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> where)
        {
            return await _collection.Find(where).FirstOrDefaultAsync();
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            var filter = Builders<T>.Filter.Where(s => s.Id.Equals(id) && s.IsDeleted == false);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }    

        public virtual async Task UpdateAsync(T entity)
        {
            await _collection.ReplaceOneAsync(s=>s.Id == entity.Id, entity);
        }

        public virtual async Task UpdateRangeAsync(ICollection<T> entities)
        {
            var requests = entities.Select(replacement => new ReplaceOneModel<T>(
                filter: new ExpressionFilterDefinition<T>(s => s.Id == replacement.Id),
                replacement: replacement){ IsUpsert = true });

            await _collection
                .BulkWriteAsync(
                    requests: requests,
                    options: new BulkWriteOptions { IsOrdered = false });
        }
    }
}
