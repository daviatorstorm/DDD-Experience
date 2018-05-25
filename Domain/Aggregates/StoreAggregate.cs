using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using Domain.Repositories;
using MongoDB.Bson;

namespace Domain.Aggregates
{
    public class StoreAggregate
    {
        private readonly StoreDomain _domain;
        private readonly IRetailerRepository _repository;

        public StoreAggregate(StoreDomain domain, IRetailerRepository repository)
        {
            _domain = domain;
            _repository = repository;
        }
        public void Create(Retailer retailer)
        {
            try
            {
                _repository.Add(retailer);
                _domain.DoCommand(CommandType.Add, retailer);
            }
            catch (Exception ex)
            {
                _domain.DoCommand(CommandType.Exception, ex);
            }
        }

        public void Update(Retailer retailer)
        {
            try
            {
                _repository.Update(retailer);
                _domain.DoCommand(CommandType.Update, retailer);
            }
            catch (Exception ex)
            {
                _domain.DoCommand(CommandType.Exception, ex);
            }
        }

        public IEnumerable<Retailer> GetAll()
        {
            try
            {
                _domain.DoCommand(CommandType.GetAll, null);
                return _repository.GetAll();
            }
            catch (Exception ex)
            { 
                _domain.DoCommand(CommandType.Exception, ex);
                return Enumerable.Empty<Retailer>();
            }
        }

        public Retailer GetById(string id)
        {
            try
            {
                _domain.DoCommand(CommandType.GetById, null);
                return _repository.GetById(ObjectId.Parse(id));
            }
            catch (Exception ex)
            {
                _domain.DoCommand(CommandType.Exception, ex);
                return null;
            }
        }

        public void Remoce(string id)
        {
            try
            {
                _domain.DoCommand(CommandType.Remove, null);
                _repository.RemoveById(ObjectId.Parse(id));
            }
            catch (Exception ex)
            {
                _domain.DoCommand(CommandType.Exception, ex);
                Enumerable.Empty<Retailer>();
            }
        }
    }
}