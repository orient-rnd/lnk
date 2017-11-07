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
            return View();
        }

        public IActionResult EditFlashCard(string id)
        {
            //id = "7ec3083bac28426fb7579cca05fa5cb6";
            var query = new GetFlashCardDetails() { Id = id };
            //var query = new GetFlashCardCategoryDetailsQuery() { Category = "2aae84001bb542b3825d73de31357c4f" };
            var detail = _queryBus.Send<GetFlashCardDetails, FlashCardDetails>(query);
            return PartialView(detail);
        }

        [HttpPost]
        public IActionResult EditFlashCard(FlashCardResponseModel respond)
        {
            var updateFlashCardCommand = new UpdateFlashCardCommand()
            {
                Id = respond.Id,
                FaceA = respond.FaceA,
                FaceB=respond.FaceB,
                FlashCardCategoryId=respond.FlashCardCategoryId,
                FlashCardCategoryName=respond.FlashCardCategoryName,
                DisplayOrder=respond.DisplayOrder
            };
            _commandBus.Send(updateFlashCardCommand);

            return RedirectToAction("Index", "Categories");
        }



    }
}
