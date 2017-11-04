using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BomBiEn.AppServices.Lnk.Models.Category;
using System.Net;
using BomBiEn.Infrastructure.Queries;
using BomBiEn.Infrastructure.Commands;
using AutoMapper;
using BomBiEn.Domain.Users.Services;
using BomBiEn.Commands.FlashCards;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BomBiEn.AppServices.Lnk.Controllers
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
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateCategory(CreateModel request)
        {
            var createFlashCardCategoryCommand = new CreateFlashCardCategoryCommand() {
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
    }
}
