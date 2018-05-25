using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Aggregates;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class RetailerController : Controller
    {
        private readonly StoreAggregate _store;

        public RetailerController(StoreAggregate store)
        {
            _store = store;
        }

        public IActionResult GetAll()
        {
            return Ok(_store.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(_store.GetById(id));
        }


        [HttpPost]
        public IActionResult Create([FromBody] Retailer retailer)
        {
            _store.Create(retailer);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Retailer retailer)
        {
            _store.Update(retailer);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _store.Remoce(id);
            return Ok();
        }
    }
}
