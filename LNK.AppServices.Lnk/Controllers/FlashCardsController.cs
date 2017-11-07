using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LNK.Queries.Users;
using LNK.Infrastructure.Queries;
using LNK.Infrastructure.Commands;
using AutoMapper;
using LNK.Queries.FlashCards;
using LNK.Queries.Categories;
using LNK.Queries.Sentences;
using LNK.Commands.FlashCards;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LNK.AppServices.Lnk.Controllers
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
            var query = new ListFlashCardsQuery() { CategoryId = "e7d259b403684e2da0a142fd1863dba6" };
            var flashCard = _queryBus.Send<ListFlashCardsQuery, PagedQueryResult<FlashCardDetails>>(query);
            var neededSentences = flashCard.Items.ToList();
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
