using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LNK.Queries.Users;
using LNK.Infrastructure.Queries;
using LNK.Infrastructure.Commands;
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
    }
}
