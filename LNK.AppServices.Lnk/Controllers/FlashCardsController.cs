using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LNK.Queries.Users;
using LNK.Infrastructure.Queries;
using LNK.Infrastructure.Commands;
using LNK.Commands.FlashCards;
using AutoMapper;
using LNK.Queries.FlashCards;
using LNK.AppServices.Lnk.Models.FlashCard;

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
            var query = new ListFlashCardCategoriesQuery() { UserEmail = "nguyenhuuloc304@gmail.com" };
            var flashCardCategories = _queryBus.Send<ListFlashCardCategoriesQuery, PagedQueryResult<FlashCardCategoryOverview>>(query);
            var neededSentences = flashCardCategories.Items.ToList();
            return View(neededSentences);
        }


        public IActionResult CreateFlashCard()
        {
            var model = new CreateFlashCardModel();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult CreateFlashCard(CreateFlashCardModel model)
        {

            var command = new CreateFlashCardCommand()
            {
                FaceA = model.FaceA,
                FaceB = model.FaceB,
                FlashCardCategoryId = "7b619936ef064116b1a91f6e00506491",
                FlashCardCategoryName = "admin-dev",
                UserEmail = "huytranprers@gmail.com",
                ViewNumber = 0,
            };
            _commandBus.Send(command);
            return RedirectToAction("Index", "FlashCards");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var command = new DeleteFlashcardCategoryCommand() { Id = id };
            _commandBus.Send(command);
            return RedirectToAction("Index", "FlashCards");
        }
    }
}