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
            var ds = User.Identity.Name;

            var users = _queryBus.Send<ListUsersQuery, PagedQueryResult<UserOverview>>(new ListUsersQuery { Email = User.Identity.Name });

            var result = new List<FlashCardCategoryOverview>();
            if (users.Items.Count() == 1)
            {
                var categoryFlashCards = _queryBus.Send<ListFlashCardCategoriesQuery, PagedQueryResult<FlashCardCategoryOverview>>(new ListFlashCardCategoriesQuery { UserId = users.Items.FirstOrDefault().Id });
                result.AddRange(categoryFlashCards.Items.ToList());
            }

            return View(result);
        }

        public IActionResult Card(string id)
        {
            var userEmail = User.Identity.Name;

            if (userEmail == null)
            {
                RedirectToRoute("Account", "Login");
            }

            var flashCards = _queryBus.Send<GetAllFlashCardsQuery, IEnumerable<FlashCardOverview>>(new GetAllFlashCardsQuery { IdCategory = id }).ToList();

            return View(flashCards.ToList());
        }
    }
}
