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

        [HttpGet]
        public IActionResult CreateFlashCard()
        {
            var model = new CreateFlashCardCommand();
            return PartialView(model);
        }
       
        [HttpPost]
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
