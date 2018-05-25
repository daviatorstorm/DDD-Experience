using System.Collections.Generic;
using Domain.Models;
using MongoDB.Bson;

namespace Domain.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T entity);
        void Update(T entity);
        T GetById(ObjectId id);
        IEnumerable<T> GetAll();
        void RemoveById(ObjectId id);
    }
}