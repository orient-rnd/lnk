using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LNK.AppServices.Lnk.Models.Category;
using System.Net;
using LNK.Infrastructure.Queries;
using LNK.Infrastructure.Commands;
using AutoMapper;
using LNK.Domain.Users.Services;
using LNK.Commands.FlashCards;
using LNK.Queries.FlashCards;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LNK.AppServices.Lnk.Controllers
{


    public class CategoriesController : Controller
    {

        private readonly IQueryBus _queryBus;
        private readonly ICommandBus _commandBus;
        private readonly IMapper _mapper;

        public CategoriesController(
            IQueryBus queryBus,
            ICommandBus commandBus,
            IMapper mapper)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
            _mapper = mapper;

        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateCategory()
        {
            var model = new CreateModel();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult CreateCategory(CreateModel request)
        {
            var createFlashCardCategoryCommand = new CreateFlashCardCategoryCommand()
            {
                Name = request.Name,
                UserId = "80c36c19eec24dd3a39b54a95b95a4bd",
                UserEmail = "nguyenhuuloc304@gmail.com",
                IsFaceAShowFirst = request.IsFaceAShowFirst,
                IsRandom = request.IsRandom,
                DisplayOrder = 1
            };
            _commandBus.Send(createFlashCardCategoryCommand);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult EditCategory(string id)
        {
            id = "7ec3083bac28426fb7579cca05fa5cb6";
            var query = new GetFlashCardCategoryDetailsQuery() { Id = id };
            //var query = new GetFlashCardCategoryDetailsQuery() { Category = "2aae84001bb542b3825d73de31357c4f" };
            var detail = _queryBus.Send<GetFlashCardCategoryDetailsQuery, FlashCardCategoryDetails>(query);
            return PartialView(detail);
        }

        [HttpPost]
        public IActionResult EditCategory(CategoryResponseModel respond)
        {
            var updateFlashCardCategoryCommand = new UpdateFlashCardCategoryCommand()
            {
                Id = respond.Id,
                UserId = respond.UserId,
                UserEmail = respond.UserEmail,
                Name = respond.Name,
                IsFaceAShowFirst = respond.IsFaceAShowFirst,
                IsRandom = respond.IsRandom,
                DisplayOrder = respond.DisplayOrder
            };
            _commandBus.Send(updateFlashCardCategoryCommand);

            return RedirectToAction("Index", "Home");
        }
    }
}