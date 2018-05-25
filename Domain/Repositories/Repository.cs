using System.Collections.Generic;
using Domain.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

namespace Domain.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly MongoContext _context;
        public Repository(MongoContext context)
        {
            _context = context;
        }

        public virtual void Add(T entity)
        {
            _context.GetCollection<T>().InsertOne(entity);
        }

        public virtual void Update(T entity)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, entity.Id);
            var update = Builders<T>.Update.Set(x => x, entity);

            _context.GetCollection<T>().UpdateOne(filter, update);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.GetCollection<T>().Find(x => true).ToList();
        }

        public virtual T GetById(ObjectId id)
        {
            return _context.GetCollection<T>().Find(x => x.Id == id).FirstOrDefault();
        }

        public virtual void RemoveById(ObjectId id)
        {
            _context.GetCollection<T>().FindOneAndDelete(x => x.Id == id);
        }
    }
}