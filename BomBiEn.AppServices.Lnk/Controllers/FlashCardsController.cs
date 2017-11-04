using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BomBiEn.Queries.Users;
using BomBiEn.Infrastructure.Queries;
using BomBiEn.Infrastructure.Commands;
using AutoMapper;
using BomBiEn.Queries.FlashCards;
using BomBiEn.Queries.Categories;
using BomBiEn.Queries.Sentences;
using BomBiEn.Commands.FlashCards;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BomBiEn.AppServices.Lnk.Controllers
{
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

        public IActionResult Index()
        {
            var query = new ListFlashCardCategoriesQuery() { UserEmail = "nguyenhuuloc304@gmail.com" };
            var flashCardCategories = _queryBus.Send<ListFlashCardCategoriesQuery, PagedQueryResult<FlashCardCategoryOverview>>(query);
            var neededSentences = flashCardCategories.Items.ToList();
            return View(neededSentences);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var command = new DeleteFlashcardCategoryCommand() { Id = id };
            _commandBus.Send(command);
            return RedirectToAction("Index", "FlashCards");
        }

        [HttpGet]
        public IActionResult CreateFlashCard(string id)
        {
            var command = new CreateFlashCardCommand()
            {
                FaceA = "face a",
                FaceB = "face b",
                FlashCardCategoryId = id,
                FlashCardCategoryName = "admin-dev",
                UserEmail = "huytranprers@gmail.com",
                DisplayOrder = 1,
                ViewNumber = 1,
            };
            _commandBus.Send(command);
            return RedirectToAction("Index", "FlashCards");
        }
    }
}
