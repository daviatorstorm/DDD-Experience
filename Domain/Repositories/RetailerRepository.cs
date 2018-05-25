using System;
using System.Collections.Generic;
using Domain.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Domain.Repositories
{
    public class RetailerRepository : Repository<Retailer>, IRetailerRepository
    {
        public RetailerRepository(MongoContext context)
            : base(context)
        {
        }

        public override void Add(Retailer entity)
        {
            entity.DateCreated = DateTime.UtcNow;
            entity.DateModifies = DateTime.UtcNow;

            base.Add(entity);
        }

        public override void Update(Retailer entity)
        {
            entity.DateModifies = DateTime.UtcNow;

            var filter = Builders<Retailer>.Filter.Eq(x => x.Id, entity.Id);
            var update = Builders<Retailer>.Update
                .Set(x => x.Name, entity.Name)
                .Set(x => x.DateModifies, entity.DateModifies)
                .Set(x => x.Group, entity.Group);

            var test = _context.Retailers.UpdateOne(filter, update);
        }
    }
}