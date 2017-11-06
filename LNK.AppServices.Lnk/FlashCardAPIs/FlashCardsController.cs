﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LNK.Infrastructure.Queries;
using LNK.Infrastructure.Commands;
using AutoMapper;
using MongoDB.Driver;
using LNK.Domain.FlashCards.Models;
using LNK.Queries.FlashCards;
using LNK.Queries.Categories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LNK.AppServices.Lnk.FlashCardAPIs
{
    [Route("api/Category")]
    public class FlashCardsController : Controller
    {
        private readonly IQueryBus _queryBus;
        private readonly ICommandBus _commandBus;
        private readonly IMapper _mapper;

        public FlashCardsController(
            IQueryBus queryBus,
            ICommandBus commandBus,
            IMapper mapper)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
            _mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}/Flashcard")]
        public IActionResult Get(string id)
        {
            var queryFlashCard = new ListFlashCardsQuery() { CategoryId = id };
            var queryCategory = new GetFlashCardCategoryInfoQuery() { Id = id };

            var flashCards = _queryBus.Send<ListFlashCardsQuery, PagedQueryResult<FlashCardOverview>>(queryFlashCard);
            var categories = _queryBus.Send<GetFlashCardCategoryInfoQuery, FlashCardCategoryInfoOverview>(queryCategory);
            List<FlashCardBrief> lstFlashCardResult = new List<FlashCardBrief>();
            foreach (var item in flashCards.Items)
            {
                lstFlashCardResult.Add(
                    new FlashCardBrief()
                    {
                        FaceA = item.FaceA,
                        FaceB = item.FaceB,
                        Order = item.DisplayOrder
                    }
            );
            }
            var result = new FlashCardFindByCategoryIdOverview()
            {
                isRandom = categories.isRandom,
                isFaceAFirst = categories.isFaceAFirst,
                Items = lstFlashCardResult
            };

            ////var result = flashCards.Items;
            return Ok(result);
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
