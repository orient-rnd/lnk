using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BomBiEn.Infrastructure.MongoDb;
using BomBiEn.Domain.FlashCards.Models;
using MongoDB.Driver;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BomBiEn.AppServices.API.Controllers
{
    [Route("api/[controller]")]
    public class FlashCardsController : Controller
    {
        private readonly IMongoDbReadRepository _readRepository;
        public FlashCardsController(IMongoDbReadRepository readRepository)
        {
            _readRepository = readRepository;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var filter = Builders<FlashCard>.Filter.Eq("FlashCardCategoryId", id);
            var flashCards = _readRepository.Find<FlashCard>(filter).ToList();
            return Ok(flashCards);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
