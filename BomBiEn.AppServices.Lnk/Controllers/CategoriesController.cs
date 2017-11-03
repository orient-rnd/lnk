using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BomBiEn.Infrastructure.Queries;
using BomBiEn.Infrastructure.Commands;
using AutoMapper;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BomBiEn.AppServices.Lnk.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IQueryBus _queryBus;
        private readonly ICommandBus _commandBus;
        private readonly IMapper _mapper;

        public CategoriesController(IQueryBus queryBus,
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
            //var query = new ListSentencesQuery() { Category = "2aae84001bb542b3825d73de31357c4f" };
            //var sentences = _queryBus.Send<ListSentencesQuery, PagedQueryResult<SentenceOverview>>(query);
            //var neededSentences = sentences.Items.ToList();
            return View();
        }
    }
}
